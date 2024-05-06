using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class ListarVentas : Form
    {
        public ListarVentas()
        {
            InitializeComponent();
            ObtenerNumeroTotalVentas();
            ObtenerPrimeraFilaList();
            ObtenerRestoFilas();
        }

        private int ObtenerNumeroTotalVentas()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) AS TotalVentas FROM VENTAS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int totalVentas = (int)command.ExecuteScalar();

                lblTotalPedidos.Text = totalVentas.ToString();
                return totalVentas;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioAdmin formularioAdmin = new FormularioAdmin();
            formularioAdmin.Show();
        }

        private int Conteo = 1;
        private void ObtenerPrimeraFilaList()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT Id FROM VENTAS ORDER BY FechaVenta ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int Id = (int)command.ExecuteScalar();

                string query2 = "SELECT FechaVenta FROM VENTAS WHERE Id = @ID";

                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@ID", Id);

                DateTime fechaVenta = (DateTime)command2.ExecuteScalar();

                string query3 = @"
                SELECT DV.NomProducto AS Producto
                FROM DETALLESVENTA DV
                INNER JOIN VENTAS V ON DV.IDVenta = V.Id
                WHERE DV.IDVenta = @ID";

                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@ID", Id);

                string nombre = (string)command3.ExecuteScalar();

                string query4 = "SELECT PrecioTotal FROM VENTAS WHERE Id = @Id";

                SqlCommand command4 = new SqlCommand(query4, connection);
                command4.Parameters.AddWithValue("@Id", Id);

                decimal precio = (decimal)command4.ExecuteScalar();

                string query5 = "SELECT DNI FROM VENTAS WHERE Id = @iD";

                SqlCommand command5 = new SqlCommand(query5, connection);
                command5.Parameters.AddWithValue("@iD", Id);

                string DNI = (string)command5.ExecuteScalar();

                ListViewItem item = new ListViewItem(Conteo.ToString());
                item.SubItems.Add(nombre.ToString());
                item.SubItems.Add(fechaVenta.ToShortDateString());
                item.SubItems.Add(precio.ToString());
                item.SubItems.Add(DNI.ToString());
                listView1.Items.Add(item);
            }
        }

        private void CrearTablaOrdenadaEnServidor()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = @"
            CREATE TABLE #TablaTemporal (
            ID INT IDENTITY(1,1),
            FechaVenta DATETIME
            )

            INSERT INTO #TablaTemporal (FechaVenta)
            SELECT FechaVenta FROM VENTAS ORDER BY FechaVenta ASC

            CREATE TABLE TablaOrdenada (
            ID INT IDENTITY(1,1),
            FechaVenta DATETIME
            )

            INSERT INTO TablaOrdenada (FechaVenta)
            SELECT FechaVenta FROM #TablaTemporal

            DROP TABLE #TablaTemporal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private bool TablaOrdenadaExiste()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TablaOrdenada'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void ObtenerRestoFilas()
        {
            if (!TablaOrdenadaExiste())
            {
                CrearTablaOrdenadaEnServidor();
            }

            int totalPedidos = ObtenerNumeroTotalVentas();

            for (int IdSiguiente = 2; IdSiguiente <= totalPedidos; IdSiguiente++)
            {
                string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
                string queryFecha = "SELECT FechaVenta FROM TablaOrdenada WHERE ID = @Ident";
                string queryId = "SELECT Id FROM VENTAS WHERE FechaVenta = @Fecha";
                string queryNombre = "SELECT DV.NomProducto AS Producto FROM DETALLESVENTA DV INNER JOIN VENTAS V ON DV.IDVenta = V.Id WHERE DV.IDVenta = @ID";
                string queryPrecio = "SELECT PrecioTotal FROM VENTAS WHERE Id = @Id";
                string queryDNI = "SELECT DNI FROM VENTAS WHERE Id = @iD";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Obtener fecha de venta
                        SqlCommand commandFecha = new SqlCommand(queryFecha, connection);
                        commandFecha.Parameters.AddWithValue("@Ident", IdSiguiente);
                        object fechaObject  = commandFecha.ExecuteScalar();
                        DateTime fecha = Convert.ToDateTime(fechaObject);

                        // Obtener ID de venta
                        SqlCommand commandId = new SqlCommand(queryId, connection);
                        commandId.Parameters.AddWithValue("@Fecha", fecha);
                        int Id = (int)commandId.ExecuteScalar();

                        // Obtener nombre de producto
                        SqlCommand commandNombre = new SqlCommand(queryNombre, connection);
                        commandNombre.Parameters.AddWithValue("@ID", Id);
                        string nombre = (string)commandNombre.ExecuteScalar();

                        // Obtener precio total
                        SqlCommand commandPrecio = new SqlCommand(queryPrecio, connection);
                        commandPrecio.Parameters.AddWithValue("@Id", Id);
                        decimal precio = (decimal)commandPrecio.ExecuteScalar();

                        // Obtener DNI
                        SqlCommand commandDNI = new SqlCommand(queryDNI, connection);
                        commandDNI.Parameters.AddWithValue("@iD", Id);
                        string DNI = (string)commandDNI.ExecuteScalar();

                        // Agregar fila a ListView
                        ListViewItem item = new ListViewItem(IdSiguiente.ToString());
                        item.SubItems.Add(nombre);
                        item.SubItems.Add(fecha.ToShortDateString());
                        item.SubItems.Add(precio.ToString());
                        item.SubItems.Add(DNI);
                        listView1.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


    }
}