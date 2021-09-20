using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2.Sav3
{
    static class Calculator
    {

        private static List<char> Functions = new List<char> { '*', '/', '+','-'};

        public static void RunCalculator()
        {
            Info();

            Console.WriteLine("Įveskite funkciją (Simboliai: '*' '/' '+' '-')");
            char funcSymbol = Convert.ToChar(Console.ReadLine());

            if (Functions.Contains(funcSymbol) == false)
            {
                Console.WriteLine("Klaidinga operacija");
                return;
            }

            Console.WriteLine("Įveskite pirmąjį skaičių");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite antrąjį skaičių");
            double b = double.Parse(Console.ReadLine());
            
            RunCalFunctions(funcSymbol, a, b);
        }

        private static void RunCalFunctions(char funcSymbol, double a, double b)
        {
            switch (funcSymbol)
            {
                case '+':
                    Addition(a, b);
                    break;

                case '-':
                    Subraction(a, b);
                    break;

                case '*':
                    Multiplication(a, b);
                    break;

                case '/':
                    Devision(a, b);
                    break;

                default:
                    Console.WriteLine("Problema Operacijose");
                    break;
            }
        }

        // Prints out information needed for the calculator
        private static void Info()
        {
            Console.WriteLine("Skaičiuotuvas");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1): sudėtis (+)");
            Console.WriteLine("2): atimtis (-)");
            Console.WriteLine("3): daugyba (*)");
            Console.WriteLine("4): dalyba  (/)");
            Console.WriteLine("-----------------------");
        }
        private static void Addition (double a, double b) => Console.WriteLine($"{a,0:f} + {b,0:f} = {(double)(a + b),0:f}");
        private static void Subraction (double a, double b) => Console.WriteLine($"{a,0:f} - {b,0:f} = {(double)(a - b),0:f}");
        private static void Multiplication (double a, double b) => Console.WriteLine($"{a,0:f} * {b,0:f} = {(double)(a * b),0:f}");

        private static void Devision (double a, double b) 
        {
            if (b == 0)
            {
                Console.WriteLine("Dalyba iš nulio negalima");
            }
            else
            {
                try
                {
                    Console.WriteLine($"{a,0:f} / {b,0:f} = {(double)(a / b),0:f}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Problema su Dalyba:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
