using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public static class gestorSesion
    {
        public static string Dni {  get; private set; }
        public static bool Admin { get; private set; }
        public static string Contrasena { get; private set; }

        public static bool inicioSesion(string dni, string contrasena, bool admin)
        {
            Dni = dni;
            Contrasena = contrasena;
            Admin = admin;

            MessageBox.Show("VARIABLES DE SESION:\n\nDNI: " + Dni + "\nContraseña :" + Contrasena + "\nAdmin: " + Admin,"Login exitoso",MessageBoxButtons.OK);

            return true;
        }

        public static bool cierreSesion()
        {
            Dni = null;
            Contrasena = null;
            Admin = false;

            return true;
        }
    }
}
