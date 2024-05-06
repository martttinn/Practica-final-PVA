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
            switch (nombreSandwich)
            {
                case "Sandwich barbacoa":
                    pictureBox.Image = Properties.Resources.Sandwich_1;
                    break;
                case "Sandwich atun":
                    pictureBox.Image = Properties.Resources.Sandwich_2;
                    break;
                case "Sandwich carbonara":
                    pictureBox.Image = Properties.Resources.Sandwich_3;
                    break;
                case "Sandwich cebolla":
                    pictureBox.Image = Properties.Resources.Sandwich_4;
                    break;
                case "Sandwich chorizo":
                    pictureBox.Image = Properties.Resources.Sandwich_5;
                    break;
                case "Sandwich jamon":
                    pictureBox.Image = Properties.Resources.Sandwich_6;
                    break;
                case "Sandwich pechuga":
                    pictureBox.Image = Properties.Resources.Sandwich_7;
                    break;
                case "Sandwich salchicha":
                    pictureBox.Image = Properties.Resources.Sandwich_8;
                    break;
                case "Sandwich jamon york":
                    pictureBox.Image = Properties.Resources.Sandwich_9;
                    break;
                default:
                    MessageBox.Show("Imagen no encontrada.");
                    break;
            }
       

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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Close();
            ListarUsuarios listarUsuarios = new ListarUsuarios();
            listarUsuarios.Show();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            this.Close();
            ListarAdministradores listarAdministradores = new ListarAdministradores();
            listarAdministradores.Show();
        }

        private void btnModificarSandwich_Click(object sender, EventArgs e)
        {
            this.Close();
            ModificarSandwichPredeterminado modificarSandwichPredeterminado = new ModificarSandwichPredeterminado();
            modificarSandwichPredeterminado.Show();
        }

    }

}
