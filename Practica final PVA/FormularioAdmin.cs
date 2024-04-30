using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Practica_final_PVA
{
    public partial class FormularioAdmin : Form
    {
        public FormularioAdmin()
        {
            InitializeComponent();
            ObtenerSandwichesMasVendidos();
        }

        private void ObtenerSandwichesMasVendidos()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT TOP 1 NomProducto FROM DETALLESVENTA GROUP BY NomProducto ORDER BY COUNT(*) DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string sandwichMasVendido = reader["NomProducto"].ToString();
                   // MessageBox.Show($"El pedido mas vendido es: " + sandwichMasVendido);

                    CargarImagenSandwich(sandwichMasVendido);
                }
                else
                {
                    MessageBox.Show("No se encontraron ventas.");
                }
                reader.Close();
            }
        }

        private void CargarImagenSandwich(string nombreSandwich)
        {
            string rutaImagen = IdentificarFoto(nombreSandwich);
            try
            {
                Imagen1.Image = Image.FromFile(rutaImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
            }
        }

        private string IdentificarFoto(string nombreSandwich)
        {
            string rutaImagen = "";
            if (nombreSandwich.Equals("Sandwich Vegetariano"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich1.jpeg";
            }

            return rutaImagen;
        }

        private void Imagen1_Click(object sender, EventArgs e)
        {

        }
    }
}
