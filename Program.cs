using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener la instancia única de la Mochila usando el patrón Singleton
            Mochila mochila = Mochila.ObtenerInstancia();
           

            // Mostrar el menú
            MostrarMenu(mochila);
        }

        static void MostrarMenu(Mochila mochila)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Agregar Artículo a la Mochila");
            Console.WriteLine("2. Mostrar Contenido de la Mochila");
            Console.WriteLine("3. Eliminar Artículo de la Mochila");
            Console.WriteLine("4. Verificar Patrón Singleton");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarArticulo(mochila);
                    MostrarMenu(mochila); // Volver a mostrar el menú
                    break;
                case "2":
                    mochila.MostrarMochila();
                    MostrarMenu(mochila); // Volver a mostrar el menú
                    break;
                case "3":
                    EliminarArticulo(mochila);
                    MostrarMenu(mochila); // Volver a mostrar el menú
                    break;
                case "4":
                    VerificarSingleton();
                    MostrarMenu(mochila); // Volver a mostrar el menú
                    break;
                case "5":
                    Console.WriteLine("Saliendo del programa. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, elige entre 1 y 5.");
                    MostrarMenu(mochila); // Volver a mostrar el menú
                    break;
            }
        }

        static void AgregarArticulo(Mochila mochila)
        {
            Console.Write("Ingresa Artículo a la Mochila: ");
            string nombreArticulo = Console.ReadLine();

            Console.Write("Ingresa Marca del Artículo: ");
            string marcaArticulo = Console.ReadLine();

            Console.Write("¿Cuántos artículos quieres agregar? ");
            string cantidadArticuloStr = Console.ReadLine();

            // Convertimos la cantidad a un número entero
            if (int.TryParse(cantidadArticuloStr, out int cantidadArticulo))
            {
                // Usamos el método de la mochila Singleton para agregar el artículo
                mochila.AgregarArticulo(nombreArticulo, marcaArticulo, cantidadArticulo);
            }
            else
            {
                Console.WriteLine("Por favor, ingresa una cantidad válida.");
            }
        }

        static void EliminarArticulo(Mochila mochila)
        {
            Console.Write("Ingresa el nombre del artículo que deseas eliminar: ");
            string nombreArticulo = Console.ReadLine();

            // Usamos el método de la mochila Singleton para eliminar el artículo
            mochila.EliminarArticulo(nombreArticulo);
        }

        static void VerificarSingleton()
        {
            // Obtener dos instancias de la clase Mochila
            Mochila instancia1 = Mochila.ObtenerInstancia();
            Mochila instancia2 = Mochila.ObtenerInstancia();

            // Mostrar detalles de las instancias para verificar si son la misma
            Console.WriteLine("\nVerificación del Patrón Singleton:");
            Console.WriteLine($"Instancia 1: {instancia1.GetHashCode()}");
            Console.WriteLine($"Instancia 2: {instancia2.GetHashCode()}");

            // Comprobar si ambas instancias son la misma
            if (ReferenceEquals(instancia1, instancia2))
            {
                Console.WriteLine("¡Correcto! Ambas instancias son la misma referencia. El patrón Singleton está funcionando.");
            }
            else
            {
                Console.WriteLine("Error: Se han creado dos instancias diferentes. El patrón Singleton no está funcionando correctamente.");
            }
        }
    }

}
