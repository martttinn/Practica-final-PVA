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
    public partial class formModificar : Form
    {
        // Conexion con la base de datos
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");
        private PerfilUsuario perfil;
        public formModificar(PerfilUsuario formUsuario)
        {
            InitializeComponent();
            perfil = formUsuario;
        }

        private void modificarDatos()
        {
            string nuevoNombre, nuevoDni, nuevaContra, confirmContra;
            string consulta = "UPDATE USUARIOS SET Nombre = @Nombre, Contrasena = @Contrasena WHERE Dni = @Dni";

            if (txtNom.Text != "")
            {
                nuevoNombre = txtNom.Text;
            }
            else
            {
                nuevoNombre= gestorSesion.getNombre();
            }

            if(txtContra.Text != "")
            {
                nuevaContra = txtContra.Text;
                confirmContra = txtContra2.Text;
                bool iguales = comprobarContrasena(nuevaContra,confirmContra);

                if (!iguales)
                {
                    MessageBox.Show("Las contaseñas no coinciden", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                nuevaContra = gestorSesion.getContrasena();
            }

            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@Dni", gestorSesion.getDni());
            comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
            comando.Parameters.AddWithValue("@Contrasena", nuevaContra);

            conexion.Open();

            int filasAfectadas = comando.ExecuteNonQuery();

            if(filasAfectadas > 0)
            {
                MessageBox.Show("Informacion modificada con exito.\n La informacion se actualizara en el perfil la proxima vez que inicies sesión", "Exito", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No se pudo modificar los datos.", "Error", MessageBoxButtons.OK);
            }

            conexion.Close();
            this.perfil.cargarInfo();
            this.Close();
        }
        private bool comprobarContrasena(string contrasena1, string contrasena2)
        {
            if (contrasena1 == contrasena2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modificarDatos();
        }
    }
}
