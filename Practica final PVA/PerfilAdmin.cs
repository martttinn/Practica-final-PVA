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
    public partial class PerfilAdmin : Form
    {
        string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
        public PerfilAdmin()
        {
            InitializeComponent();
            ObtenerNombre();
            ObtenerDNI();
            ObtenerTipo();
            ObtenerId();
        }

        private void ObtenerNombre()
        {
            string dni = gestorSesion.getDni();
            string query = "SELECT Nombre FROM USUARIOS WHERE DNI = @DNI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DNI", dni);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        lblNombre.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con el DNI especificado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el usuario en la base de datos: " + ex.Message);
                }
            }
        }

        private void ObtenerDNI()
        {
            string DNI = gestorSesion.getDni();
            lblDNI.Text = DNI;
        }

        private void ObtenerTipo()
        {
            string dni = gestorSesion.getDni();
            string query = "SELECT Admin FROM USUARIOS WHERE DNI = @DNI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DNI", dni);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        bool esAdmin = (bool)result;
                        if (esAdmin)
                        {
                            lblTipo.Text = "Administrador";
                        }
                        else
                        {
                            lblTipo.Text = "Usuario";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con el DNI especificado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el usuario en la base de datos: " + ex.Message);
                }
            }
        }

        private void ObtenerId()
        {
            string dni = gestorSesion.getDni();
            string query = "SELECT Id FROM USUARIOS WHERE DNI = @DNI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DNI", dni);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        lblId.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con el DNI especificado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el usuario en la base de datos: " + ex.Message);
                }
            }
        }

        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            string dni = gestorSesion.getDni();
            string query = "SELECT Contrasena FROM USUARIOS WHERE DNI = @DNI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DNI", dni);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        lblContrasena.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con el DNI especificado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el usuario en la base de datos: " + ex.Message);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioAdmin formularioAdmin = new FormularioAdmin();
            formularioAdmin.ShowDialog();
            
        }
    }
}