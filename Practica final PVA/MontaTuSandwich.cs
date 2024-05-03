using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Xml.XPath;
using System.Security.AccessControl;

namespace Practica_final_PVA
{
    public partial class MontaTuSandwich : Form
    {
        public MontaTuSandwich()
        {
            InitializeComponent();
            cargarIngredientes();
        }

        // Conexion con la base de datos
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");

        // Tabla de datos donde almacenar los ingredientes extraidos de la base de datos
        private DataTable ingredientes = new DataTable();

        // Objeto sandwich para poder montarlo a gusto
        Sandwich sandwich = new Sandwich();

        private void cargarIngredientes()
        {
            string Consulta = "SELECT Nombre, Tipo, Precio FROM INGREDIENTES;";
            SqlCommand comando = new SqlCommand(Consulta, conexion);

            // Este adaptador de datos sirve para llenar la tabla de ingredientes
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(ingredientes);

            foreach (DataRow fila in ingredientes.Rows)
            {
                string nombre = fila["Nombre"].ToString();
                int tipo = (int)fila["Tipo"];

                switch (tipo)
                {
                    case 1:
                        cbProteina.Items.Add(nombre);
                        break;

                    case 2:
                        cbVerdura.Items.Add(nombre);
                        break;

                    case 3:
                        cbqueso.Items.Add(nombre);
                        break;

                    case 4:
                        cbSalsa.Items.Add(nombre);
                        break;

                    default:
                        MessageBox.Show("Error cargando los ingredientes.");
                        break;
                }

            }
        }

        private void anadirIngredientes()
        {

            string nombreProte, nombreVerdu, nombreQueso, nombreSalsa;
            int numProte, numVerdu, numQueso, numSalsa;

            nombreProte = cbProteina.Text;
            numProte = (int)udProteina.Value;

            nombreVerdu = cbVerdura.Text;
            numVerdu = (int)udVerdura.Value;

            nombreQueso = cbqueso.Text;
            numQueso = (int)udQueso.Value;

            nombreSalsa = cbSalsa.Text;
            numSalsa = (int)udSalsa.Value;

            if (nombreProte != "" & numProte > 0)
            {
                Ingrediente Proteina = new Ingrediente(nombreProte, ObtenerPrecio(nombreProte), 1, numProte);
                sandwich.agregarIngrediente(Proteina);

                ListViewItem prote = new ListViewItem(new[] { nombreProte, numProte.ToString(), ObtenerPrecio(nombreProte).ToString() });
                lvSandwich.Items.Add(prote);
            }

            if (nombreVerdu != "" & numVerdu > 0)
            {
                Ingrediente Verdura = new Ingrediente(nombreVerdu, ObtenerPrecio(nombreVerdu), 2, numVerdu);
                sandwich.agregarIngrediente(Verdura);

                ListViewItem verdu = new ListViewItem(new[] { nombreVerdu, numVerdu.ToString(), ObtenerPrecio(nombreVerdu).ToString() });
                lvSandwich.Items.Add(verdu);
            }

            if (nombreQueso != "" & numQueso > 0)
            {
                Ingrediente Queso = new Ingrediente(nombreQueso, ObtenerPrecio(nombreQueso), 3, numQueso);
                sandwich.agregarIngrediente(Queso);

                ListViewItem queso = new ListViewItem(new[] { nombreQueso, numQueso.ToString(), ObtenerPrecio(nombreQueso).ToString() });
                lvSandwich.Items.Add(queso);
            }

            if (nombreSalsa != "" & numSalsa > 0)
            {
                Ingrediente Salsa = new Ingrediente(nombreSalsa, ObtenerPrecio(nombreSalsa), 4, numSalsa);
                sandwich.agregarIngrediente(Salsa);

                ListViewItem salsa = new ListViewItem(new[] { nombreSalsa, numSalsa.ToString(), ObtenerPrecio(nombreSalsa).ToString() });
                lvSandwich.Items.Add(salsa);
            }

            float precioTotal = sandwich.calcularPrecio();
            lblPrecioTotal.Text = precioTotal.ToString();
        }

        // Método para obtener el precio de un ingrediente por su nombre
        private float ObtenerPrecio(string nombre)
        {
            DataRow[] rows = ingredientes.Select($"Nombre = '{nombre}'");
            if (rows.Length > 0)
            {
                return Convert.ToSingle(rows[0]["Precio"]);
            }
            return 0.0f;
        }

        // Método para obtener el tipo de un ingrediente por su nombre
        private int ObtenerTipo(string nombre)
        {
            DataRow[] rows = ingredientes.Select($"Nombre = '{nombre}'");
            if (rows.Length > 0)
            {
                return Convert.ToInt32(rows[0]["Tipo"]);
            }
            return 0;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            anadirIngredientes();

            cbProteina.SelectedIndex = -1;
            cbVerdura.SelectedIndex = -1;
            cbqueso.SelectedIndex = -1;
            cbSalsa.SelectedIndex = -1;
            udProteina.Value = 0;
            udVerdura.Value = 0;
            udQueso.Value = 0;
            udSalsa.Value = 0;
        }

        private void EliminarIngrediente()
        {
            if (lvSandwich.SelectedItems.Count > 0)
            {
                string nombre = lvSandwich.SelectedItems[0].Text;

                foreach (ListViewItem item in lvSandwich.SelectedItems)
                {
                    lvSandwich.Items.Remove(item);
                }

                sandwich.eliminarIngrediente(nombre);
                lblPrecioTotal.Text = (sandwich.calcularPrecio()).ToString();

            }
            else
            {

                MessageBox.Show("Por favor, selecciona un ingrediente para eliminar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarIngrediente();
        }

        private void ExportarFactura()
        {

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            worksheet.Cells[1, 1] = "Nombre";
            worksheet.Cells[1, 2] = "Cantidad";
            worksheet.Cells[1, 3] = "Precio";


            int indiceFila = 2;
            foreach (ListViewItem item in lvSandwich.Items)
            {
                worksheet.Cells[indiceFila, 1] = item.SubItems[0].Text; // Nombre
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

        private void registrarVenta()
        {
            string dniCliente = gestorSesion.getDni();

            DateTime fecha = DateTime.Now.Date;

            float precioTotal = this.sandwich.calcularPrecio();
            precioTotal = (float)Math.Round(precioTotal, 2);

            string insert = "INSERT INTO VENTAS(Dni, FechaVenta, PrecioTotal) VALUES(@Dni, @FechaVenta, @PrecioTotal)";
            int filasAfectadas = 0;

            int idVenta = 0;

            SqlCommand comando = new SqlCommand(insert,conexion);
            comando.Parameters.AddWithValue("@Dni", dniCliente);
            comando.Parameters.AddWithValue("@FechaVenta", fecha);
            comando.Parameters.AddWithValue("@PrecioTotal", precioTotal);

            string selectId = "SELECT Id FROM VENTAS WHERE Dni = @Dni2 AND FechaVenta = @FechaVenta2 AND PrecioTotal = @PrecioTotal2";
            
            SqlCommand comando2 = new SqlCommand(selectId, conexion);
            comando2.Parameters.AddWithValue("@Dni2", dniCliente);
            comando2.Parameters.AddWithValue("@FechaVenta2", fecha);
            comando2.Parameters.AddWithValue("@PrecioTotal2", precioTotal);

            try
            {
                conexion.Open();

                filasAfectadas = comando.ExecuteNonQuery();

                idVenta = (int)comando2.ExecuteScalar();

                foreach (Ingrediente ingrediente in sandwich.ingredientes)
                {   
                    string nombreIngrediente = ingrediente.getNombre();
                    int unidadesIngrediente = ingrediente.getUnidades();
                    int idIngrediente = ObtenerIdIngrediente(nombreIngrediente);

                    if (idIngrediente != -1)
                    {
                        string insertDetalle = "INSERT INTO DETALLESVENTA(IDVenta, NomProducto, IDIngrediente, Cantidad) VALUES(@IDVenta, @NomProducto, @IDIngrediente, @Cantidad)";
                        SqlCommand comandoDetalle = new SqlCommand(insertDetalle, conexion);
                        comandoDetalle.Parameters.AddWithValue("@IDVenta", idVenta);
                        comandoDetalle.Parameters.AddWithValue("@NomProducto", "Sandwich personalizado");
                        comandoDetalle.Parameters.AddWithValue("@IDIngrediente", idIngrediente);
                        comandoDetalle.Parameters.AddWithValue("@Cantidad", unidadesIngrediente);
                        comandoDetalle.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error con los ingredientes.", "Error");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("se produjo un error:" + ex.Message, "Error");
            }

            if(filasAfectadas > 0)
            {
                DialogResult resultado = MessageBox.Show("Pedido registrado con exito.\n¿Desea exportar la factura a excel?", "Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resultado == DialogResult.Yes)
                {
                    ExportarFactura();
                }
            }
            else
            {
                MessageBox.Show("Error al realizar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            conexion.Close();
        }

        private int ObtenerIdIngrediente(string nombreIngrediente)
        {
            string consulta = "SELECT Id FROM INGREDIENTES WHERE Nombre = @Nombre";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@Nombre", nombreIngrediente);
            int idIngrediente = -1;

            try
            {
                idIngrediente = (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID del ingrediente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return idIngrediente;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            registrarVenta();
        }


    }
}
