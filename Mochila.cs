using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Mochila
    {
        // Instancia privada estática para el Singleton
        private static Mochila _instancia = null;
        


        // Lista de artículos en la mochila
        private List<Articulo> MochilaArticulos;

        // El constructor privado asegura que no se pueda crear una instancia externa
        private Mochila()
        {
            MochilaArticulos = new List<Articulo>();
        }

        // Método público estático para obtener la instancia única
        public static Mochila ObtenerInstancia()
        {
            // Doble verificación de bloqueo para asegurar que solo se crea una instancia
            if (_instancia == null)
            {
                lock (typeof(Mochila))
                {
                    if (_instancia == null)
                    {
                        _instancia = new Mochila();
                    }
                }
            }
            return _instancia;
        }

        // Método para agregar un artículo a la mochila
        public void AgregarArticulo(string nombre, string marca, int cantidad)
        {
            Articulo nuevoArticulo = new Articulo(nombre, marca, cantidad);
            MochilaArticulos.Add(nuevoArticulo);
            Console.WriteLine($"Artículo '{nombre}' agregado con éxito.");
        }

        // Método para mostrar los artículos en la mochila
        public void MostrarMochila()
        {
            if (MochilaArticulos.Count == 0)
            {
                Console.WriteLine("No hay artículos en la mochila.");
                return;
            }

            Console.WriteLine("\n____MOCHILA____");
            foreach (var articulo in MochilaArticulos)
            {
                articulo.MostrarInformacion();
            }
        }

        // Método para eliminar un artículo de la mochila
        public void EliminarArticulo(string nombre)
        {
            // Buscar el artículo por su nombre
            var articulo = MochilaArticulos.Find(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (articulo != null)
            {
                MochilaArticulos.Remove(articulo);
                Console.WriteLine($"Artículo '{nombre}' eliminado con éxito.");
            }
            else
            {
                Console.WriteLine($"No se encontró un artículo llamado '{nombre}'.");
            }
        }
    }

}
