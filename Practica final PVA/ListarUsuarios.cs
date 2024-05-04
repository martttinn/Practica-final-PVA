using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class ListarUsuarios : Form
    {
        public ListarUsuarios()
        {
            InitializeComponent();
            ObtenerFilasList();
            ObtenerNumeroTotalUsuarios();
        }

        private void ObtenerNumeroTotalUsuarios()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) AS TotalUsuarios FROM Usuarios WHERE Admin = @admin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string fs = "False";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@admin", fs);
                connection.Open();

                int totalVentas = (int)command.ExecuteScalar();

                lblTotalUsuarios.Text = totalVentas.ToString();
            }
        }

        private void CrearTablaSoloUsuarios()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = @"
            CREATE TABLE #TablaTemporal2 (
            ID INT IDENTITY(1,1),
            Dni NVARCHAR(9) 
            )

            INSERT INTO #TablaTemporal2 (Dni)
            SELECT Dni FROM USUARIOS WHERE Admin = 0

            CREATE TABLE TablaSoloUsuarios (
            ID INT IDENTITY(1,1),
            Dni NVARCHAR(9)
            )

            INSERT INTO TablaSoloUsuarios (Dni)
            SELECT Dni FROM #TablaTemporal2

            DROP TABLE #TablaTemporal2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        private bool TablaSoloUsuariosExiste()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TablaSoloUsuarios'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void ObtenerFilasList()
        {
            if (!TablaSoloUsuariosExiste())
            {
                CrearTablaSoloUsuarios();
            }

            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = @"
                SELECT Id, Dni, Nombre, Contrasena, (
                    SELECT COUNT(*) 
                    FROM VENTAS 
                    WHERE DNI = U.Dni
                ) AS TotalComprasUsuario
                FROM USUARIOS U
                WHERE Admin = 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Id"].ToString());
                    item.SubItems.Add(reader["Dni"].ToString());
                    item.SubItems.Add(reader["Nombre"].ToString());
                    item.SubItems.Add(reader["Contrasena"].ToString());
                    item.SubItems.Add(reader["TotalComprasUsuario"].ToString());
                    listView1.Items.Add(item);
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
