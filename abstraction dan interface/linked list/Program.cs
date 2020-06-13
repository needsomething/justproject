using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "";
            Node Root = null;
            Tampilan menu = new Tampilan();
            do
            {
                a = menu.Menu_awal();
                switch (a)
                {
                    case "a":
                        Root = menu.Add_begin(Root);
                        break;
                    case "b":
                        Root = menu.Add_end(Root);
                        break;
                    case "c":
                        Root = menu.add_after(Root);
                        break;
                    case "d":
                        menu.Show(Root);
                        break;
                    case "e":
                        Root = menu.Pop(Root);
                        break;
                    case "f":
                        break;
                }
            } while (a != "f");
            Console.ReadKey();
        }
    }
}
