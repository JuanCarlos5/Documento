using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Introduce el nombre del archivo: ");
        string nombreArchivo = Console.ReadLine();

        Console.Write("Introduce el contenido del archivo: ");
        string contenido = Console.ReadLine();

        try
        {
            using (StreamWriter sw = File.CreateText(nombreArchivo))
            {
                sw.WriteLine(contenido);
            }

            Console.WriteLine($"Archivo '{nombreArchivo}' creado y contenido escrito con éxito.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al crear o escribir en el archivo: " + e.Message);
            return;
        }

        Console.WriteLine("¿Qué deseas hacer? (editar, mostrar, finalizar)");
        string opcion = Console.ReadLine();

        while (opcion.ToLower() != "finalizar")
        {
            if (opcion.ToLower() == "editar")
            {
                Console.Write("Introduce el texto que deseas agregar al archivo: ");
                string textoAgregar = Console.ReadLine();

                try
                {
                    using (StreamWriter sw = File.AppendText(nombreArchivo))
                    {
                        sw.WriteLine(textoAgregar);
                    }

                    Console.WriteLine("Texto agregado al archivo con éxito.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error al editar el archivo: " + e.Message);
                }
            }
            else if (opcion.ToLower() == "mostrar")
            {
                try
                {
                    using (StreamReader sr = new StreamReader(nombreArchivo))
                    {
                        string linea;
                        Console.WriteLine($"Contenido del archivo '{nombreArchivo}':");
                        while ((linea = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(linea);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrió un error al leer el archivo: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.WriteLine("¿Qué deseas hacer? (editar, mostrar, finalizar)");
            opcion = Console.ReadLine();
        }
    }
}
