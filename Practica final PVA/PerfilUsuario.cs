using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        public PerfilUsuario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            cargarInfo();
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
