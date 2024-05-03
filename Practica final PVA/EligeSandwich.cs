using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class EligeSandwich : Form
    {
        private List<SandwichPredefinido> sandwiches;
        private List<SandwichPredefinido> Cesta;

        private decimal precioTotal;

        // Conexion con la base de datos
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");
        public EligeSandwich()
        {
            InitializeComponent();

            sandwiches = new List<SandwichPredefinido>();
            Cesta = new List<SandwichPredefinido>();

            cargarSandwiches();
        }

        private void cargarSandwiches()
        {
            string consulta = "SELECT Id, Nombre, Precio FROM PRODUCTOS";

            SqlCommand comando = new SqlCommand(consulta,conexion);

            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            while(lector.Read())
            {
                int id = (int)lector["Id"];
                string nombre = lector["Nombre"].ToString();
                decimal precio = Convert.ToDecimal(lector["Precio"]);
                
                SandwichPredefinido sandwich = new SandwichPredefinido(id,nombre,precio);
                
                sandwiches.Add(sandwich);
            }

            lector.Close();
            conexion.Close();

            foreach(SandwichPredefinido sandwich in sandwiches)
            {
                cbSandwiches.Items.Add(sandwich.getNombre());
            }
        }

        private void anadirSandwich()
        {
            if(cbSandwiches.Text != "" && udUnidades.Value > 0)
            {
                string nomSandwich = cbSandwiches.Text;

                foreach(SandwichPredefinido sandwich in sandwiches)
                {
                    if(nomSandwich.Equals(sandwich.getNombre()))
                    {
                        sandwich.setUnidades((int)udUnidades.Value);

                        ListViewItem item = new ListViewItem(nomSandwich);
                        
                        item.SubItems.Add(sandwich.getUnidades().ToString());
                        item.SubItems.Add(sandwich.getPrecioUnitario().ToString());

                        lvSandwich.Items.Add(item);

                        this.Cesta.Add(sandwich);    
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un sandwich y las unidades primero","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anadirSandwich();
            calcPrecioTotal();
        }

        private void calcPrecioTotal()
        {
            this.precioTotal = 0;

            foreach(SandwichPredefinido sandwich in Cesta)
            {
                this.precioTotal += sandwich.calcPrecio();
            }

            lblPrecioTotal.Text = this.precioTotal.ToString();
        }

        private decimal calcPrecioTotalReturn()
        {
            this.precioTotal = 0;

            foreach (SandwichPredefinido sandwich in Cesta)
            {
                this.precioTotal += sandwich.calcPrecio();
            }

            return this.precioTotal;
        }

        private void eliminarSandwich()
        {
            SandwichPredefinido sandwichAEliminar = null;

            if(lvSandwich.SelectedItems.Count > 0)
            {
                string nombre = lvSandwich.SelectedItems[0].Text;

                foreach (ListViewItem item in lvSandwich.SelectedItems)
                {
                    lvSandwich.Items.Remove(item);
                }

                foreach(SandwichPredefinido sandwich in Cesta)
                {
                    if(nombre.Equals(sandwich.getNombre()))
                    {
                        sandwichAEliminar = sandwich;
                    }
                }

                Cesta.Remove(sandwichAEliminar);

                calcPrecioTotal();
            }
            else
            {

                MessageBox.Show("Por favor, selecciona un ingrediente para eliminar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarSandwich();
        }

        private void registrarVenta()
        {
            string dniCliente = gestorSesion.getDni();

            DateTime fecha = DateTime.Now.Date;

            decimal precioTotal = calcPrecioTotalReturn();

            string insert = "INSERT INTO VENTAS(Dni, FechaVenta, PrecioTotal) VALUES(@Dni, @FechaVenta, @PrecioTotal)";
            int filasAfectadas = 0;

            int idVenta = 0;

            SqlCommand comando1 = new SqlCommand(insert, conexion);
            comando1.Parameters.AddWithValue("@Dni",dniCliente);
            comando1.Parameters.AddWithValue("@FechaVenta", fecha);
            comando1.Parameters.AddWithValue("@PrecioTotal", precioTotal);

            string selectId = "SELECT Id FROM VENTAS WHERE Dni = @Dni2 AND FechaVenta = @FechaVenta2 AND PrecioTotal = @PrecioTotal2";

            SqlCommand comando2 = new SqlCommand(selectId, conexion);
            comando2.Parameters.AddWithValue("@Dni2", dniCliente);
            comando2.Parameters.AddWithValue("@FechaVenta2", fecha);
            comando2.Parameters.AddWithValue("@PrecioTotal2", precioTotal);

            try
            {
                conexion.Open();

                filasAfectadas = comando1.ExecuteNonQuery();

                if(filasAfectadas == 0)
                {
                    MessageBox.Show("Hubo un error al registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                idVenta = (int)comando2.ExecuteScalar();

                if(Cesta.Count > 1)
                {
                    filasAfectadas = 0;

                    foreach (SandwichPredefinido sandwich in Cesta)
                    {
                        string nombreSandwich = sandwich.getNombre();
                        int unidades = sandwich.getUnidades();

                        string insertDetalle = "INSERT INTO DETALLESVENTA(IDVenta, NomProducto, Cantidad) VALUES(@IDVenta, @NomProducto, @Cantidad)";
                        SqlCommand comandoDetalle = new SqlCommand(insertDetalle, conexion);
                        comandoDetalle.Parameters.AddWithValue("@IDVenta", idVenta);
                        comandoDetalle.Parameters.AddWithValue("@NomProducto", nombreSandwich);
                        comandoDetalle.Parameters.AddWithValue("@Cantidad", unidades);

                        filasAfectadas = comandoDetalle.ExecuteNonQuery();
                    }

                    if (filasAfectadas != 0)
                    {
                        DialogResult resultado = MessageBox.Show("Pedido registrado con exito.\n¿Desea exportar la factura a excel?", "Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            ExportarFactura();
                        }
                    }

                }
                else if(Cesta.Count == 1)
                {
                    filasAfectadas = 0;

                    SandwichPredefinido sandwich = Cesta[0];

                    string nombreSandwich = sandwich.getNombre();
                    int unidades = sandwich.getUnidades();

                    string insertDetalle = "INSERT INTO DETALLESVENTA(IDVenta, NomProducto, Cantidad) VALUES(@IDVenta, @NomProducto, @Cantidad)";
                    SqlCommand comandoDetalle = new SqlCommand(insertDetalle, conexion);
                    comandoDetalle.Parameters.AddWithValue("@IDVenta", idVenta);
                    comandoDetalle.Parameters.AddWithValue("@NomProducto", nombreSandwich);
                    comandoDetalle.Parameters.AddWithValue("@Cantidad", unidades);

                    filasAfectadas = comandoDetalle.ExecuteNonQuery();

                    if (filasAfectadas != 0)
                    {
                        DialogResult resultado = MessageBox.Show("Pedido registrado con exito.\n¿Desea exportar la factura a excel?", "Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            ExportarFactura();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Hubo un error contando los elementos del pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                conexion.Close();


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error:" + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registrarVenta();
            
        }

        private void ExportarFactura()
        {

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            worksheet.Cells[1, 1] = "Producto";
            worksheet.Cells[1, 2] = "Cantidad";
            worksheet.Cells[1, 3] = "Precio";


            int indiceFila = 2;
            foreach (ListViewItem item in lvSandwich.Items)
            {
                worksheet.Cells[indiceFila, 1] = item.SubItems[0].Text; // Producto
                worksheet.Cells[indiceFila, 2] = item.SubItems[1].Text; // Cantidad
                worksheet.Cells[indiceFila, 3] = item.SubItems[2].Text; // Precio
                indiceFila++;
            }

            worksheet.Cells[indiceFila, 1] = "Precio Total:";
            worksheet.Cells[indiceFila, 3] = lblPrecioTotal.Text;


            string NomArchivo = "Factura.xlsx";
            workbook.SaveAs(NomArchivo);


            workbook.Close();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            MessageBox.Show("Factura exportada con exito a Excel", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
