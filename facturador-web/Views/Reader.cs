using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Views
{
    internal class Reader
    {
        //El reader siempre va a recibir un message que es el que se envia desde Writer

        //Lector de cadenas o strings
        public static string StringReader()
        {   
            //Declaracion de variables
            string? input;

            do
            {
                input = Console.ReadLine();
                //Validamos si es nulo o vacio
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un valor válido:");
                }
                
            } while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input));

            //Retornamos el valor de input sin espacios en blanco al inicio o al final
            return input.Trim();
        }

        public static long IntReader()
        {
            string? input;
            long intValue;

            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !long.TryParse(input, out intValue))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero:");
                }

            } while (string.IsNullOrEmpty(input) || !long.TryParse(input, out intValue));


            //Retornamos el valor de input sin espacios en blanco al inicio o al final
            return intValue;
        }

        public static float FloatReader()
        {             
            //Declaracion de variable input
            string? input;
            float floatValue;

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || !float.TryParse(input, out floatValue))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número decimal:");
                }
                //Si el valor de input es nulo o vacio, volvemos a pedir el valor
            } while (string.IsNullOrEmpty(input) || !float.TryParse(input, out floatValue));

            //Retornamos el valor de input convertido a float
            return floatValue;
        }

        public char CharReader()
        {
            //Declaracion de variable input
            string? input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.Length != 1)
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un solo caracter:");
                }

            } while (string.IsNullOrEmpty(input) || input.Length != 1);

            //Retornamos el primer caracter del valor de input
            return input[0];
        }



        public DateTime DateReader()
        {

            string? input;
            DateTime dateValue;

            do
            {
                input = Console.ReadLine();

                if (!DateTime.TryParse(input, out dateValue))
                {
                    Console.WriteLine("Formato de fecha invalido. Por favor, ingrese una fecha valida.");
                }
            } while (string.IsNullOrEmpty(input) || !DateTime.TryParse(input, out dateValue));

            //Retornamos el valor de input convertido a DateTime
            return dateValue;
        }


    }
}
