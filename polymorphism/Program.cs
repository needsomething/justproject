using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterWindows printer;
            Console.WriteLine("Pilih Printer :\n1. Epson\n2. Canon\n3. LaserJet\n");
            Console.Write("Nomor Printer [1...3] : ");
            int jwb = int.Parse(Console.ReadLine());

            if(jwb == 1)
            {
                printer = new Epson();
            }
            else if(jwb == 2)
            {
                printer = new Canon();
            }
            else
            {
                printer = new LaserJet();
            }

            printer.Show();
            printer.Print();
            Console.ReadKey();
        }
    }
}
