using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_final_PVA
{
    internal class SandwichPredefinido
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private decimal precio { get; set; }
        private int unidades { get; set; }

        public SandwichPredefinido(int id, string nombre, decimal precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.unidades = 0;
        }

        public string getNombre()
        {
            return nombre;
        }

        public decimal getPrecioUnitario()
        {
            return precio;
        }

        public int getId()
        {
            return id;
        }

        public int getUnidades()
        {
            return unidades;
        }

        public void setUnidades(int unidades)
        {
            this.unidades = unidades;
        }

        public decimal calcPrecio()
        {
            return precio * unidades;
        }
    }
}
