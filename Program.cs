using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("masukkan nilai a : ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("masukkan nilai b : ");
            float b = float.Parse(Console.ReadLine());
            while (true)
            {
                Console.WriteLine("+ - * / %");
                Console.Write("masukkan pilihan : ");
                char jwb = char.Parse(Console.ReadLine());
                if (jwb == '+')
                {
                    Console.WriteLine("{0} + {1} = {2}", a, b, tambah(a, b));
                    break;
                }
                else if (jwb == '-')
                {
                    Console.WriteLine("{0} - {1} = {2}", a, b, kurang(a, b));
                    break;
                }
                else if (jwb == '*')
                {
                    Console.WriteLine("{0} * {1} = {2}", a, b, kali(a, b));
                    break;
                }
                else if (jwb == '/')
                {
                    Console.WriteLine("{0} / {1} = {2}", a, b, bagi(a, b));
                    break;
                }
                else if (jwb == '%')
                {
                    Console.WriteLine("{0} % {1} = {2}", a, b, modulo(a, b));
                    break;
                }
            }
            Console.ReadKey();
        }
        static float tambah(float a, float b)
        {
            return a + b;
        }
        static float kurang(float a, float b)
        {
            return a - b;
        }
        static float kali(float a, float b)
        {
            return a * b;
        }
        static float bagi(float a, float b)
        {
            return a / b;
        }
        static float modulo(float a, float b)
        {
            return a % b;
        }
    }
}
