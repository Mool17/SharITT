using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Articulo
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }

        public Articulo(string nombre, string marca, int cantidad)
        {
            Nombre = nombre;
            Marca = marca;
            Cantidad = cantidad;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Artículo: {Nombre}, Marca: {Marca}, Cantidad: {Cantidad}");
        }
    }
}
