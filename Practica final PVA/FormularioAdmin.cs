using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class FormularioAdmin : Form
    {
        public FormularioAdmin()
        {
            InitializeComponent();
        }

        private void ObtenerSandwichMasVendido()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT Producto, COUNT(*) AS TotalVentas FROM VENTAS GROUP BY Producto ORDER BY TotalVentas DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string sandwichMasVendido = reader["Producto"].ToString();
                    MessageBox.Show("El sandwich más vendido es: " + sandwichMasVendido);
                }
                else
                {
                    MessageBox.Show("No se encontraron ventas.");
                }
                reader.Close();
            }
        }

        private void Imagen1_Click(object sender, EventArgs e)
        {

        }
    }
}
