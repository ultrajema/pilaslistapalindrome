﻿using Pilasta.clases;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Pilastack
{
    class Program
    {

        static void ejemploPilaLineal()
        {
            PilaLineal pila;
            int x;
            int CLAVE = -1;

            PilaLista pilaLista = new PilaLista();
            PilaLineal pilaLineal = new PilaLineal();
            PilaListaSimple listaEnla = new PilaListaSimple();

            Console.WriteLine("Ingrese numeros y para terminar -1");
            try
            {
                pila = new PilaLineal();
                do
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    if(x!= -1)
                    {
                        pilaLineal.insertar(x);
                        pilaLista.insertar(x);
                        listaEnla.InsertarList(x);
                    }

                } while (x != CLAVE);

                int pausa;
                pausa = 0;

                Console.WriteLine("DATOS DE LA PILA LISTA ENLAZADA: ");
                listaEnla.Inverso();

                Console.WriteLine("DATOS DE LA PILA LINEAL: ");
                while (!pilaLineal.pilaVacia())
                {
                    x = (int)(pilaLineal.quitarChar());
                    Console.WriteLine($"Elemento:{x}");

                }



                //pila.insertar(900);


            }
            catch (Exception error)
            {
                Console.WriteLine("Error= " + error.Message);
            }
        }

        static void palindromo()
        {
            PilaLineal pilaChar;
            bool esPalindromo;
            String pal;
            PilaListaSimple listaEnla = new PilaListaSimple();
            PilaLista pilaLista = new PilaLista();
            PilaLineal pilaLineal = new PilaLineal();

            try
            {
                pilaChar = new PilaLineal();
                Console.WriteLine("Teclee una palabra para ver si es palindromo");
                pal = Console.ReadLine();

              
                string remplazada = Regex.Replace(pal, @"\s", ""); 
                string convertida = remplazada.ToLower(); 
                Regex reg = new Regex("[^a-zA-Z0-9]"); 

                
                //para que la cadena Unicode se normalize mediante la descomposición canónica completa.
                string textoNormalizado = convertida.Normalize(NormalizationForm.FormD); 
                string textoSA = reg.Replace(textoNormalizado, "");
                

                //creacion pila con chars
                for (int i = 0; i < textoSA.Length;)
                {
                    Char c;
                    c = textoSA[i++];
                    pilaChar.insertar(c);
                    pilaLista.insertar(c);
                    listaEnla.InsertarList(c);
                }

                Console.WriteLine("Tu palabra a la inversa es: ");
                listaEnla.Inverso();

                //comprueba si es palindromo
                esPalindromo = true;

                int pausa;
                pausa = 0;

                for (int j = 0; esPalindromo && !listaEnla.ListaVacia();)
                {
                    Char c;
                    c = (Char)listaEnla.quitarChar();
                    esPalindromo = textoSA[j++] == c; //evalua si la pos es igual 
                }
                listaEnla.LimpiarPila();
                if (esPalindromo)
                {
                    Console.WriteLine($"la palabra {pal} si es un palindromo");
                }
                else
                {
                    Console.WriteLine($"lamentablemente no es un palindromo");
                }

            }
            catch (Exception error)
            {
                Console.WriteLine($"ups error {error.Message}");
            }

        }
    

        static void EjemploPilaLista()
        {
            int x;
            PilaListaSimple listaEnla = new PilaListaSimple();
            PilaLista pilaLista = new PilaLista();
            PilaLineal pilaLineal = new PilaLineal();

            listaEnla.InsertarList(1); pilaLineal.insertar(1); pilaLista.insertar(1);
            listaEnla.InsertarList(5); pilaLineal.insertar(5); pilaLista.insertar(5);
            listaEnla.InsertarList(16); pilaLineal.insertar(16); pilaLista.insertar(16);
            listaEnla.InsertarList(217); pilaLineal.insertar(217); pilaLista.insertar(217);
            listaEnla.InsertarList(41); pilaLineal.insertar(41); pilaLista.insertar(41);
            listaEnla.InsertarList(19); pilaLineal.insertar(19); pilaLista.insertar(19);

            //var xx = listaEnla.eliminar();
            //var xx = pl.quitar();

            Console.WriteLine("DATOS DE LA PILA: ");
            listaEnla.Inverso();

            int pausa;
            pausa = 0;

            
        }
    

    static void Matexpre()
        {
            string infija;
            Console.WriteLine("Escribir la expresion a evaluar porfavor:");
            infija = Console.ReadLine();

           Console.WriteLine("el resultado es: " + Evaluadorexpre.evaluar(infija));
        }

        static void Main(string[] args)
        {
            
            //ejemploPilaLineal();
           //palindromo();
           //EjemploPilaLista();
            //Matexpre();

            
        }
    }
}
