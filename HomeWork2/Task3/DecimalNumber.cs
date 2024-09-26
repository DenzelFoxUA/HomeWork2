using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWork2.Task3
{

    public struct DecimalNumber
    {
        public int NumberValue { get; set; }

        public DecimalNumber(int value) 
        { 
            NumberValue = value; 
        }

        public Stack<byte> MakeItBinary()
        {
            var bits = new Stack<byte>();
            string text = string.Empty;
            int buffer = NumberValue;

            do
            {
                bits.Push((byte)(buffer % 2));
                buffer /= 2;
            }
            while (buffer > 0) ;

            foreach (var bit in bits)
            {
                text += bit;
            }

            Console.WriteLine(text);

            return bits;
        }

        public Stack<byte> MakeItOctal()
        {

            var octal = new Stack<byte>();
            string text = string.Empty;
            int buffer = NumberValue;

            do
            {
                octal.Push((byte)(buffer % 8));

                buffer /= 8;
            }
            while (buffer > 0);

            foreach (var item in octal)
            {
                text += item;
            }

            Console.WriteLine(text);

            return octal;
        }

        public Stack<char> MakeItHexadecimal()
        {
            
            char[] letters = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'];

            var hexes = new Stack<char>();
            string text = string.Empty;
            int buffer = NumberValue;

            do
            {
                int remainder = buffer % 16;
                hexes.Push(letters[remainder]);

                buffer /= 16;
            }
            while (buffer > 0);

            foreach (var item in hexes)
            {
                text += item;
            }

            Console.WriteLine(text);

            return hexes;
        }
    }
}
