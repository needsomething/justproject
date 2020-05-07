using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_polymorphism
{
    public class PrinterWindows
    {
        public string Dimension_x { get; set; }
        public string Dimension_y { get; set; }
        public string Tipe { get; set; }
        public virtual void Show(){}
        public virtual void Print(){}
    }
    public class Epson : PrinterWindows
    {
        public override void Show()
        {
            Dimension_x = "10";
            Dimension_y = "11";
            Tipe = "Epson";
            Console.WriteLine("{0} Display Dimension = {1}*{2}", Tipe, Dimension_x, Dimension_y);
        }
        public override void Print()
        {
            Console.WriteLine("{0} Printer Printing", Tipe);
        }
    }

    public class Canon : PrinterWindows
    {
        public override void Show()
        {
            Dimension_x = "9.5";
            Dimension_y = "12";
            Tipe = "Canon";
            Console.WriteLine("{0} Display Dimension = {1}*{2}", Tipe, Dimension_x, Dimension_y);
        }
        public override void Print()
        {
            Console.WriteLine("{0} Printer Printing...", Tipe);
        }
    }

    public class LaserJet : PrinterWindows
    {
        public override void Show()
        {
            Dimension_x = "12";
            Dimension_y = "12";
            Tipe = "LaserJet";
            Console.WriteLine("{0} Display Dimension = {1}*{2}", Tipe, Dimension_x, Dimension_y);
        }
        public override void Print()
        {
            Console.WriteLine("{0} Printer Printing", Tipe);
        }
    }
}
