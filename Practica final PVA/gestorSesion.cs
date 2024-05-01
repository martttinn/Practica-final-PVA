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
        public static string Nombre { get; private set; }
        public static bool Admin { get; private set; }
        public static string Contrasena { get; private set; }


        public static string getDni()
        {
            return Dni;
        }

        public static string getNombre()
        {
            return Nombre;
        }

        public static bool getAdmin()
        {
            return Admin;
        }

        public static string getContrasena()
        {
            return Contrasena;
        }

        public static bool inicioSesion(string dni, string nombre, string contrasena, bool admin)
        {
            Dni = dni;
            Nombre = nombre;
            Contrasena = contrasena;
            Admin = admin;

            return true;
        }

        public static bool cierreSesion()
        {
            Dni = null;
            Nombre = null;
            Contrasena = null;
            Admin = false;

            return true;
        }
    }
}
