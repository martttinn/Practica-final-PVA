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
    public partial class InsertarSandwichPredeterminado : Form
    {
        private int pictureBoxSeleccionado = -1;
        public InsertarSandwichPredeterminado()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioAdmin formularioAdmin = new FormularioAdmin();
            formularioAdmin.Show();
        }

        private void btnAgregarSandwich_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevoNombre.Text) || string.IsNullOrWhiteSpace(txtNuevoPrecio.Text))
            {
                MessageBox.Show("Debes especificar el nombre y el precio del nuevo producto.");
                return;
            }

            string nombre = txtNuevoNombre.Text.Trim();
            decimal precio;

            if (!decimal.TryParse(txtNuevoPrecio.Text.Trim(), out precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "INSERT INTO PRODUCTOS (Nombre, Precio) VALUES (@Nombre, @Precio)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Precio", precio);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Nuevo producto agregado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el nuevo producto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el nuevo producto: " + ex.Message);
                }
            }
        }

    }

}
