using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Models
{
    internal class Reader
    {
        //El reader siempre va a recibir un message que es el que se envia desde Writer

        //Lector de cadenas o strings
        public static string StringReader(string message)
        {   
            //Declaracion de variables
            string? input;

            do
            {
                //Imprimimos el mensaje en consola
                Console.Write(message);
                //le asignamos el valor de la consola a la variable input
                input = Console.ReadLine();

                //Si el valor de input es nulo o vacio, volvemos a pedir el valor
            } while (string.IsNullOrEmpty(input));

            //Retornamos el valor de input sin espacios en blanco al inicio o al final
            return input.Trim();
        }

        public static int IntReader()
        {
            //Declaracion de variables
            
            string input;
            int intValue;

            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)||!int.TryParse(input, out intValue))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero:");
                }

            } while (string.IsNullOrEmpty(input)||!int.TryParse(input, out intValue));
            return intValue;
        }

        public static float FloatReader(string message)
        {             
            //Declaracion de variable input
            string? input;
            //Declaracion de variable floatValue
            float floatValue;
            do
            {
                //Imprimimos el mensaje en consola
                Console.Write(message);
                //le asignamos el valor de la consola a la variable input
                input = Console.ReadLine();

                //Si el valor de input es nulo o vacio, volvemos a pedir el valor
            } while (string.IsNullOrEmpty(input) || !float.TryParse(input, out floatValue));

            //Retornamos el valor de input convertido a float
            return floatValue;
        }

        public char CharReader(string message)
        {
            //Declaracion de variable input
            string? input;
            do
            {
                //Imprimimos el mensaje en consola
                Console.WriteLine(message);
                //le asignamos el valor de la consola a la variable input
                input = Console.ReadLine();

                //Si el valor de input es nulo o vacio, volvemos a pedir el valor
            } while (string.IsNullOrEmpty(input) || input.Length != 1);

            //Retornamos el primer caracter del valor de input
            return input[0];
        }



        public DateTime DateReader(string message)
        {
            //Declaracion de variable input
            string? input;
            //Declaracion de variable dateValue
            DateTime dateValue;
            do
            {
                //Imprimimos el mensaje en consola
                Console.WriteLine(message);

                //le asignamos el valor de la consola a la variable input
                input = Console.ReadLine();

                if (!DateTime.TryParse(input, out dateValue))
                {
                    Console.WriteLine("Formato de fecha invalido. Por favor, ingrese una fecha valida.");
                }

                //Si el valor de input es nulo o vacio, volvemos a pedir el valor
            } while (string.IsNullOrEmpty(input) || !DateTime.TryParse(input, out dateValue));

            //Retornamos el valor de input convertido a DateTime
            return dateValue;
        }


    }
}
