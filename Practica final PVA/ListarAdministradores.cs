using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class ListarAdministradores : Form
    {
        public ListarAdministradores()
        {
            InitializeComponent();
            ObtenerNumeroTotalAdministradores();
        }

        private void ObtenerNumeroTotalAdministradores()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) AS TotalUsuarios FROM Usuarios WHERE Admin = @admin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string fs = "True";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@admin", fs);
                connection.Open();

                int totalVentas = (int)command.ExecuteScalar();

                lblTotalAdministradores.Text = totalVentas.ToString();
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
