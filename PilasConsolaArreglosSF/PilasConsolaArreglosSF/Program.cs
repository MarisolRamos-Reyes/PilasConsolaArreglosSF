using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PilasConsolaArreglosSF
{
    class Program
    {
        static void Main(string[] args)
        {
            int tamaño;
            Console.WriteLine("capture el tamañoo de la pila");
            tamaño = int.Parse(Console.ReadLine());
            string[] pila = new string[tamaño];
            string Elemento = "";
            string res = "";

            do
            {
                Console.Write("\n\nMenú  \n 1)Ingrear elemento a la pila  \n 2)Muestra pila \n 3)Quitar elemento de la cima\n 4)Guardar pila \n 0)Salir \n\n");

                res = Console.ReadLine();

                switch (res)
                {
                    case "1":
                        Console.Write("INGRESAR VALORES A LA PILA \n");
                        Console.Write("Escriba el dato a ingresar a la pila:");
                        Elemento = Console.ReadLine();

                        while (Elemento == null)
                        {
                            Console.Write("Ingrese un valor válido a la pila:");
                            Elemento = Console.ReadLine();
                        }

                        if (estaLlena(pila))
                        {
                            Console.Write("La pila está llena, imposible agregar nuevo valor \n");
                        }
                        else
                        {
                            Push(pila, Elemento);
                        }

                        break;

                    case "2":
                        Console.Write("MOSTRAR PILA \n");

                        if (esVacia(pila))
                        {
                            Console.Write("La pila está vacia \n");
                        }
                        else
                        {
                            Mostrar(pila);
                        }
                        break;


                    case "3":
                        Console.Write("QUITAR ELEMENTO DE LA PILA \n");

                        if (esVacia(pila))
                        {
                            Console.Write("La pila tiene espacio en la disponible \n");
                        }
                        else
                        {
                            Pop(pila);
                            Console.Write("El elemento de la cima suprimido");
                        }

                        break;

                    case "4":
                        string fecha = DateTime.Now.ToString("yyyyMMdd_hhmmss");
                        string path = @"C:\arreglosConsola\" + fecha + ".txt";
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            for (int i = 0; i < pila.Length; i++)
                            {
                                sw.WriteLine(pila[i].ToString() + "");
                            }

                        }
                        break;

                    default:
                        Console.Write("saliendo");
                        break;
                }
            } while (!res.Equals("0"));
        }
        //string fecha =DateTime.Now.ToString("yyyyMMdd_hhmmss");
        //lc.Guardar("ListaCircular"+fecha);

        //public void Guardar(string[] pila)
        //{

        //    using (StreamWriter writer = new StreamWriter("prueba.txt", false))
        //    {
        //        for (int i = 0; i < pila.Length; i++)
        //        { 
        //            writer.WriteLine(pila[i].ToString() +  "");
        //        }
        //    }
        //}

        static public bool esVacia(string[] pila)
        {
            bool fl = true;

            for (int i = pila.Length - 1; i >= 0; i--)
            {
                if (pila[i] != null)
                {
                    fl = false;
                    break;
                }
            }
            return fl;
        }

        static public bool estaLlena(string[] pila)
        {
            bool fl = false;
            int count = 0;

            for (int i = pila.Length - 1; i >= 0; i--)
            {
                if (pila[i] != null)
                {
                    count += 1;
                }
            }

            if (count == pila.Length)
            {
                fl = true;
            }

            return fl;
        }
        static public bool Pop(string[] pila)
        {
            bool fl = false;

            for (int i = pila.Length - 1; i >= 0; i--)
            {
                if (pila[i] != null)
                {
                    pila[i] = null;
                    fl = true;
                    break;
                }
            }

            return fl;
        }
        static public bool Push(string[] pila, string elemento)
        {
            bool fl = false;

            for (int i = pila.Length - 1; i >= 0; i--)
            {
                if (pila[i] != null)
                {
                    pila[i + 1] = elemento;
                    fl = true;
                    break;
                }
                else if (pila[i] == null && i == 0)
                {
                    pila[i] = elemento;
                    fl = true;
                    break;
                }
            }
            return fl;
        }
        static public void Mostrar(string[] pila)
        {
            for (int i = pila.Length - 1; i >= 0; i--)
            {
                if (pila[i] != null)
                {
                    Console.Write(pila[i] + "\n");
                }
            }

        }
    
    }
}
