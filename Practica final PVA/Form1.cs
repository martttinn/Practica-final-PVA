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
    public partial class Form1 : Form
    {
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void iniciarSesion(string Dni, string contrasena)
        {

            string consulta1 = "";
            string consulta2 = "";
            int resultado1 = 0;
            string resultado2 = "";

            if(rbAdmin.Checked)
            {
                consulta1 = "SELECT COUNT(*) FROM Usuarios WHERE Dni = @Dni AND Contrasena = @Contrasena AND Admin = 1";
                consulta2 = "SELECT Nombre FROM Usuarios WHERE Dni = @Dni AND Contrasena = @Contrasena AND Admin = 1";
            }
            else if(rbUsuario.Checked)
            {
                consulta1 = "SELECT COUNT(*) FROM Usuarios WHERE Dni = @Dni AND Contrasena = @Contrasena AND Admin = 0";
                consulta2 = "SELECT Nombre FROM Usuarios WHERE Dni = @Dni AND Contrasena = @Contrasena AND Admin = 0";
            }
            else
            {
                MessageBox.Show("Por favor seleccione el tipo de usuario","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            SqlCommand comando1 = new SqlCommand(consulta1,conexion);
            SqlCommand comando2 = new SqlCommand(consulta2, conexion);

            comando1.Parameters.AddWithValue("@Dni",Dni);
            comando1.Parameters.AddWithValue("@Contrasena", contrasena);

            comando2.Parameters.AddWithValue("@Dni", Dni);
            comando2.Parameters.AddWithValue("@Contrasena", contrasena);

            conexion.Open();

            resultado1 = (int)comando1.ExecuteScalar();
            resultado2 = (string)comando2.ExecuteScalar();

            if(resultado1 > 0 && rbAdmin.Checked)
            {
               if(gestorSesion.inicioSesion(Dni, resultado2, contrasena, true))
               {
                    Console.WriteLine("Exito en el inicio de sesión");
                    FormularioAdmin formAdmin = new FormularioAdmin();
                    formAdmin.Show();
                    this.Hide();
                }
            }
            else if(resultado1 > 0 && rbUsuario.Checked)
            {
                if (gestorSesion.inicioSesion(Dni, resultado2, contrasena, false))
                {
                    Console.WriteLine("Exito en el inicio de sesion");
                    panelInicio formInicio = new panelInicio();
                    formInicio.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Dni o contraseña incorrectos","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

            conexion.Close();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string dni, contrasena;
            
            dni = txtDni.Text;
            contrasena = txtContrasena.Text;

            iniciarSesion(dni, contrasena);
        }

        private void cbMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (txtContrasena.PasswordChar == '*')
            {
                txtContrasena.PasswordChar = '\0';
            }
            else
            {
                txtContrasena.PasswordChar = '*';
            }

        }

        private void CerrarForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
