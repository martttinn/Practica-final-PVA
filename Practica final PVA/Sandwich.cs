using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_final_PVA
{
    internal class Sandwich
    {
        private string nombre { get; set; }
        private float precio { get; set; }
        public List<Ingrediente> ingredientes;

        public Sandwich()
        {
            ingredientes = new List<Ingrediente>();
        }
        public string getNombre()
        {
            return nombre;
        }
        public void agregarIngrediente(Ingrediente ingrediente)
        {
            ingredientes.Add(ingrediente);
        }

        public void eliminarIngrediente(string nombre)
        {
            Ingrediente ingredienteElim = null;

            foreach(Ingrediente ing in ingredientes)
            {
                if(nombre.Equals(ing.getNombre()))
                {
                    ingredienteElim = ing;
                }
            }

            ingredientes.Remove(ingredienteElim);
        }

        public List<Ingrediente> getIngredientes()
        {
            return ingredientes;
        }

        public float calcularPrecio()
        {
            this.precio = 0;
            foreach(Ingrediente ingrediente in ingredientes)
            {
                this.precio += (ingrediente.getPrecio() * ingrediente.getUnidades());
            }

            return this.precio;
        }

        public string toString()
        {
            string descripcion = "";
            foreach(Ingrediente ing in this.ingredientes)
            {
                string nombre = ing.getNombre();
                string unidades = (ing.getUnidades()).ToString();
                descripcion += (nombre + " unidades: " + unidades + "\n");
            }

            return descripcion;
        }
        
    }
}
