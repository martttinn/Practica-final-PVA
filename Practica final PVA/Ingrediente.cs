using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_final_PVA
{
    internal class Ingrediente
    {
        private string nombre { get; set; }
        private float precio { get; set; }
        private int tipo { get; set; }
        private int unidades { get; set; }

        public Ingrediente(string nombre, float precio, int tipo,int unidades)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.tipo = tipo;
            this.unidades = unidades;
        }

        public float getPrecio()
        {
            return precio;
        }

        public string getNombre()
        {
            return nombre;
        }

        public int getTipo()
        {
            return tipo;
        }

        public int getUnidades()
        {
            return unidades;
        }

    }
}
