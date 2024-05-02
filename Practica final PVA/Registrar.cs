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
    public partial class Registrar : Form
    {
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");
        
        public Registrar()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void registrar()
        {
            string dni, nombre, contrasena, contrasena2, insert1 = "", insert2 = "";
            int filasAfectadas= 0;

            nombre = txtNom.Text;
            dni = txtDni.Text;
            contrasena = txtContrasena.Text;
            contrasena2 = txtContrasena2.Text;
            SqlCommand comando;

            if(rbAdmin.Checked)
            {
                insert1 = "INSERT INTO USUARIOS (Dni,Nombre,Contrasena,Admin) VALUES (@Dni,@Nombre,@Contrasena,1)";
                comando = new SqlCommand(insert1, conexion);
            }
            else if (rbUsuario.Checked)
            {
                insert2 = "INSERT INTO USUARIOS (Dni,Nombre,Contrasena,Admin) VALUES (@Dni,@Nombre,@Contrasena,0)";
                comando = new SqlCommand(insert2, conexion);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione el tipo de usuario","Error",MessageBoxButtons.OK);
                return;
            }
            
            if(comprobarContrasena(contrasena,contrasena2))
            {

                conexion.Open();

                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);

                filasAfectadas = comando.ExecuteNonQuery();

                if(filasAfectadas > 0)
                {
                    MessageBox.Show("Usuario registrado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar al usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden","Error",MessageBoxButtons.OK);
                return;
            }
        }

        private bool comprobarContrasena(string contrasena1, string contrasena2)
        {
            if(contrasena1 == contrasena2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void limpiar()
        {
            txtDni.Text = "";
            txtNom.Text = "";
            txtContrasena.Text = "";
            txtContrasena2.Text = "";
            rbAdmin.Checked = false;
            rbUsuario.Checked = false;
        }

        private void cbMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMostrar.Checked)
            {
                txtContrasena.UseSystemPasswordChar = false;
                txtContrasena2.UseSystemPasswordChar = false;
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true;
                txtContrasena2.UseSystemPasswordChar = true;
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            registrar();
        }
    }
}
