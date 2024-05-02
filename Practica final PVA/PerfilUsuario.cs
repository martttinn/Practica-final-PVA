using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class PerfilUsuario : Form
    {
        private string dni, nombre, contrasena;
        private bool admin;
        private panelInicio panelInicial;

        // Conexion con la base de datos
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");

        public PerfilUsuario(panelInicio panelInicial)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panelInicial = panelInicial;
            InitializeComponent();
            cargarInfo();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            gestorSesion.cierreSesion();

            this.Close();
            this.panelInicial.Close();

            Form1 formInicial = new Form1();
            formInicial.Show();
        }

        private void cbMostrar_CheckedChanged(object sender, EventArgs e)
        {
            cargarInfo();
        }

        private void cargarInfo()
        {
            this.dni = gestorSesion.getDni();
            this.nombre = gestorSesion.getNombre();
            this.contrasena = gestorSesion.getContrasena();
            this.admin = gestorSesion.getAdmin();

            string consulta = "SELECT FechaVenta, PrecioTotal FROM VENTAS WHERE Dni = @Dni";

            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@Dni", this.dni);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable datosVentas = new DataTable();
            adaptador.Fill(datosVentas);

            dgvVentas.DataSource = datosVentas;

            string bienvenida = "Bienvenido/a, " + this.nombre;
            lblBienvenida.Text = bienvenida.ToUpper();

            lblNom.Text = this.nombre;
            lblDni.Text = this.dni;

            string contrasenaOculta = new string('*', this.contrasena.Length);

            if (cbMostrar.Checked )
            {
                lblContrasena.Text = this.contrasena;
            }
            else
            {
                lblContrasena.Text = contrasenaOculta;
            }

            if(admin)
            {
                lblAdmin.Text = "Si";
            }
            else
            {
                lblAdmin.Text = "No";
            }
        }
    }
}
