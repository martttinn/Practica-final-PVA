using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class ListarAdministradores : Form
    {
        private const bool AdminTrue = true;

        public ListarAdministradores()
        {
            InitializeComponent();
            ObtenerNumeroTotalAdministradores();
            ObtenerFilasList();
        }

        private void ObtenerNumeroTotalAdministradores()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) AS TotalAdministradores FROM Usuarios WHERE Admin = @admin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@admin", AdminTrue);

                try
                {
                    connection.Open();
                    int totalAdministradores = (int)command.ExecuteScalar();
                    lblTotalAdministradores.Text = totalAdministradores.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el número de administradores: " + ex.Message);
                }
            }
        }

        private void CrearTablaSoloAdministradores()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = @"
            CREATE TABLE #TablaTemporal3 (
            ID INT IDENTITY(1,1),
            Dni NVARCHAR(9) 
            )

            INSERT INTO #TablaTemporal3 (Dni)
            SELECT Dni FROM USUARIOS WHERE Admin = @admin

            CREATE TABLE TablaSoloAdministradores (
            ID INT IDENTITY(1,1),
            Dni NVARCHAR(9)
            )

            INSERT INTO TablaSoloAdministradores (Dni)
            SELECT Dni FROM #TablaTemporal3

            DROP TABLE #TablaTemporal3";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@admin", AdminTrue);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la tabla de administradores: " + ex.Message);
                }
            }
        }

        private bool TablaSoloAdministradoresExiste()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TablaSoloAdministradores'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar la existencia de la tabla de administradores: " + ex.Message);
                    return false;
                }
            }
        }

        private void ObtenerFilasList()
        {
            if (!TablaSoloAdministradoresExiste())
            {
                CrearTablaSoloAdministradores();
            }

            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT Id, Dni, Nombre, Contrasena FROM USUARIOS WHERE Admin = @admin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@admin", AdminTrue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Id"].ToString());
                        item.SubItems.Add(reader["Dni"].ToString());
                        item.SubItems.Add(reader["Nombre"].ToString());
                        item.SubItems.Add(reader["Contrasena"].ToString());
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los administradores: " + ex.Message);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioAdmin formularioAdmin = new FormularioAdmin();
            formularioAdmin.Show();
        }
    }
}
