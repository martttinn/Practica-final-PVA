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
            ObtenerNumeroTotalVentas();
            ObtenerFechaUltimaVenta();
            ObtenerSandwichMenosVendido();
            ObtenerIngredienteMasUsado();
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

                    CargarImagenSandwich(sandwichMasVendido, Imagen1);
                }
                else
                {
                    MessageBox.Show("No se encontraron ventas.");
                }
                reader.Close();
            }
        }

        private void CargarImagenSandwich(string nombreSandwich, PictureBox pictureBox)
        {
            string rutaImagen = IdentificarFoto(nombreSandwich);
            try
            {
                pictureBox.Image = Image.FromFile(rutaImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
            }
        }

        private string IdentificarFoto(string nombreSandwich)
        {
            string rutaImagen = "";
            if (nombreSandwich.Equals("Sandwich barbacoa"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich barbacoa.jpeg";
            }
            else if(nombreSandwich.Equals("Sandwich de atun"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich de atun.jpeg";
            }else if (nombreSandwich.Equals("Sandwich de carbonara"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich de carbonara.jpeg";
            }
            else if (nombreSandwich.Equals("Sandwich de cebolla"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich de cebolla.jpeg";
            }
            else if (nombreSandwich.Equals("Sandwich de chorizo"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich de chorizo.jpeg";
            }
            else if (nombreSandwich.Equals("Sandwich de jamon"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich de jamon.jpeg";
            }
            else if (nombreSandwich.Equals("Sandwich de pechuga"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich de pechuga.jpeg";
            }
            else if (nombreSandwich.Equals("Sandwich de salchicha"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich de salchicha.jpeg";
            }
            else if (nombreSandwich.Equals("Sandwich jamon york"))
            {
                rutaImagen = "C:/Programacion visual avanzada/Trabajo Final PVA/imagenes/sandwich jamon york.jpeg";
            }

            return rutaImagen;
        }

        private void ObtenerNumeroTotalVentas()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) AS TotalVentas FROM VENTAS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int totalVentas = (int)command.ExecuteScalar();

                lblTotalPedidos.Text = totalVentas.ToString();
            }
        }

        private void ObtenerFechaUltimaVenta()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT TOP 1 FechaVenta FROM VENTAS ORDER BY FechaVenta DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                object fechaUltimaVenta = command.ExecuteScalar();

                if (fechaUltimaVenta != null)
                {
                    DateTime fecha = (DateTime)fechaUltimaVenta;
                    lblUltimaFechaPedido.Text = fecha.ToString("dd-MM-yyyy");
                }
                else
                {
                    lblUltimaFechaPedido.Text = "No hay ventas registradas.";
                }
            }
        }

        private void ObtenerSandwichMenosVendido()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT TOP 1 NomProducto FROM DETALLESVENTA GROUP BY NomProducto ORDER BY COUNT(*) ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string sandwichMenosVendido = reader["NomProducto"].ToString();

                    CargarImagenSandwich(sandwichMenosVendido, Imagen3);
                }
                else
                {
                    MessageBox.Show("No se encontraron ventas.");
                }
                reader.Close();
            }
        }

        private void ObtenerIngredienteMasUsado()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = @"
             SELECT TOP 1 I.Nombre AS Ingrediente
             FROM DETALLESVENTA DV
             INNER JOIN INGREDIENTES I ON DV.IDIngrediente = I.Id
             GROUP BY DV.IDIngrediente, I.Nombre
             ORDER BY COUNT(*) DESC
             ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string ingredienteMasUsado = reader["Ingrediente"].ToString();
                    lblIngredienteTop.Text = ingredienteMasUsado;
                }
                else
                {
                    MessageBox.Show("No se encontraron registros de ingredientes en ventas.");
                }
                reader.Close();
            }
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            this.Close();
            PerfilAdmin perfilAdmin = new PerfilAdmin();
            perfilAdmin.Show();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnListarVentas_Click(object sender, EventArgs e)
        {
            this.Close();
            ListarVentas listarVentas = new ListarVentas();
            listarVentas.Show();
        }
    }

}
