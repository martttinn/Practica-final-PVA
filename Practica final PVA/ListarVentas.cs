using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class ListarVentas : Form
    {
        public ListarVentas()
        {
            InitializeComponent();
            ObtenerNumeroTotalVentas();
            ObtenerFilasList();
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

        private void CrearTablaOrdenadaEnServidor()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = @"
                CREATE TABLE TablaOrdenada (
                ID INT IDENTITY(1,1),
                FechaVenta DATETIME,
                NomProducto NVARCHAR(100),
                PrecioTotal DECIMAL(18,2),
                DNI NVARCHAR(20)
                )

                INSERT INTO TablaOrdenada (FechaVenta, NomProducto, PrecioTotal, DNI)
                SELECT V.FechaVenta, DV.NomProducto, V.PrecioTotal, V.DNI
                FROM VENTAS V
                INNER JOIN DETALLESVENTA DV ON V.Id = DV.IDVenta
                ORDER BY V.FechaVenta ASC";

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

        private void ActualizarTablaOrdenada()
        {
            // Truncar la tabla existente para eliminar los datos antiguos
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string truncateQuery = "TRUNCATE TABLE TablaOrdenada";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand truncateCommand = new SqlCommand(truncateQuery, connection);
                connection.Open();
                truncateCommand.ExecuteNonQuery();
            }

            // Insertar los datos actualizados ordenados por fecha de venta
            string insertQuery = @"
            INSERT INTO TablaOrdenada (FechaVenta, NomProducto, PrecioTotal, DNI)
            SELECT V.FechaVenta, DV.NomProducto, V.PrecioTotal, V.DNI
            FROM VENTAS V
            INNER JOIN DETALLESVENTA DV ON V.Id = DV.IDVenta
            ORDER BY V.FechaVenta ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
        }


        private void ObtenerFilasList()
        {
            if (!TablaOrdenadaExiste())
            {
                CrearTablaOrdenadaEnServidor();
            }
            else
            {
                ActualizarTablaOrdenada();
            }

            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT * FROM TablaOrdenada";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string IdSiguiente = reader["ID"].ToString();
                        string nombre = reader["NomProducto"].ToString();
                        DateTime fecha = (DateTime)reader["FechaVenta"];
                        string precio = reader["PrecioTotal"].ToString();
                        string DNI = reader["DNI"].ToString();

                        ListViewItem item = new ListViewItem(IdSiguiente);
                        item.SubItems.Add(nombre);
                        item.SubItems.Add(fecha.ToShortDateString());
                        item.SubItems.Add(precio);
                        item.SubItems.Add(DNI);
                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
