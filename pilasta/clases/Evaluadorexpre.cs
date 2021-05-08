using System;
using System.Collections.Generic;
using System.Text;

namespace Pilasta.clases
{
    class Evaluadorexpre
    {


        
        


        //metodo para poder convertir nuestra expresion y poder evaluarla

        public static double evaluar(String infija)
        {
            String posfija = convertir(infija); //para convertir la expresion infija a posfija
            Console.WriteLine("La expresion posfija es: " + posfija);
            return evaluarPosfija(posfija); //evaluamos la expresion posfija

        }

        //conversion de la expresion
        private static String convertir(String infija)
        {
            //conversion de la expresion infija
            String posfija = ""; //esta variable nos servira para recorrer este string caracter por caracter
            PilaLineal pila = new PilaLineal();
            


            for (int i = 0; i < infija.Length; i++)
            {
                //evaluamos si el operador es un caracter o numero
                //si este es un numero enviarlo a la expresion posfija
                //SI ES OPERADOR VERIFICAR SI LA PILA ESTA VACIA Y SI ESTA VACIA LO APILAMOS

                char letra = infija[i];//para que me devuelva el primer caracter el que esta en la posicion 0

                if (esOperador(infija[i])) 
                {
                    
                    if (pila.pilaVacia()) //si esta vacia la pila apilamos  la letra
                    {
                        pila.insertar(letra); 
                    }
                    else 
                    {
                        int pe = prioridadEnExpresion(letra); //prioridad en expresion
                        int pp = prioridadEnPila((char)pila.cimaPila()); //prioridad en pila char para que lo convierta en caracter
                        if (pe > pp) //si la prioridad en expresion es mayor a la prioridad en pila
                        {
                            pila.insertar(letra); //apilamos la letra
                        }
                        else
                        {
                            //desapilar el operador y apilar el nuevo
                            posfija += pila.quitarChar(); //desapilamos la expresion 
                            pila.insertar(letra); //y apilamos el operador
                        }
                    }
                }
                else //SI NO ES UN OPERADOR
                {
                    posfija += letra;
                }
            }
            //Para sacar todo lo que esta en la pila
            while (!pila.pilaVacia())
            {
                posfija += pila.quitarChar();
            }
            return posfija;
        }



        //EVALUAR EXPRESION POSFIJA
        private static double evaluarPosfija(String posfija)
        {
            PilaLineal pila = new PilaLineal();
            
            //recorrer el string
            for (int i = 0; i < posfija.Length; i++)
            {
                char letra = posfija[i]; //Evaluacion de los caracteres letra por letra

                if (!esOperador(letra))
                {
                    double num = Convert.ToDouble(letra + ""); //apilamos la letra convertida a numero que es el que vamos a apilar
                    pila.insertar(num); //apilamos el numero 
                }
                else //Si no es operador
                {
                    double num2 = (double)pila.quitarChar(); //Primero desapilamos el numero 2
                    double num1 = (double)pila.quitarChar();
                    double num3 = operacion(letra, num1, num2); //Metodo operacion para hacer la operacion
                    pila.insertar(num3); //apilamos el numero 3
                }
            }
            return (double)pila.cimaPila();
        }



        //METODO PARA DEVOLVER LA PRIORIDAD EN EXPRESION INFIJA
        private static int prioridadEnExpresion(char operador)
        {
            //Prioridad en la expresion infija
            if (operador == '^') return 4;
            if (operador == '*' || operador == '/') return 2;
            if (operador == '+' || operador == '-') return 1;
            if (operador == '(') return 5;
            return 0;

        }

        //METODO PARA DEVOLVER LA PRIORIDAD EN PILA
        private static int prioridadEnPila(char operador)
        {
            //Prioridad en la pila
            if (operador == '^') return 3;
            if (operador == '*' || operador == '/') return 2;
            if (operador == '+' || operador == '-') return 1;
            if (operador == '(') return 0;
            return 0;

        }

        

        //METODO PARA SABER SI ES UN OPERADOR
        private static bool esOperador(char letra)
        {
            if (letra == '*' || letra == '/' || letra == '+' || letra == '-' || letra == '(' || letra == ')' || letra == '^')
            {
                return true;
            }
            return false;

        }

       
        private static double operacion(char letra, double num1, double num2)
        {
            if (letra == '*') return num1 * num2;
            if (letra == '/') return num1 / num2;
            if (letra == '+') return num1 + num2;
            if (letra == '-') return num1 - num2;
            if (letra == '^') return Math.Pow(num2, num2);
            return 0;

        }



    }
}


