using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task3
{
    public static class Task3
    {
        public static void Run()
        {
            int number1;

            const int INPUT_LOWER_LIMIT = 0;

            string input = string.Empty;
            bool correctInput = false;

            do
            {
                Console.Write("Enter number bigger than zero: ");
                input = Console.ReadLine();
                correctInput = int.TryParse(input, out number1);
                if(!correctInput && number1 >= INPUT_LOWER_LIMIT)
                {
                    Console.WriteLine("Wrong input. Press enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (!correctInput);
            
            DecimalNumber decNum = new(number1);

            Console.Write("Binary: ");
            var binary = decNum.MakeItBinary();

            Console.Write("Hexadecimal: ");
            var hexa = decNum.MakeItHexadecimal();

            Console.Write("Octal: ");
            var octal = decNum.MakeItOctal();
            Console.ReadLine();

        }
    }
}
