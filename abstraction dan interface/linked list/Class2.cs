using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list
{
    abstract class Menu
    {
        public abstract string Menu_awal();
        public abstract Node Add_begin(Node Root);
        public abstract Node Add_end(Node Root);
        public abstract Node add_after(Node Root);
        public abstract void Show(Node Root);
        public abstract Node Pop(Node Root);
    }

    class Tampilan : Menu
    {
        Queue_list queue = new Queue_list();
        public override string Menu_awal()
        {
            Console.WriteLine("\tlinked list\na.tambah diawal\nb.tambah diakhir\nc.tambah setelah\nd.tampilkan\ne.dikeluarkan\nf.exit");
            Console.Write("pilihan : ");
            string a = Console.ReadLine();
            return a;
        }

        private int input_angka()
        {
            Console.Write("masukkan angka : ");
            int new_data = int.Parse(Console.ReadLine());
            return new_data;
        }

        public override Node Add_begin(Node Root)
        {
            int new_data = input_angka();
            Root = queue.Add_begin(Root, new_data);
            Console.WriteLine();
            return Root;
        }

        public override Node Add_end(Node Root)
        {
            int new_data = input_angka();
            Root = queue.Add_end(Root, new_data);
            Console.WriteLine();
            return Root;
        }

        public override Node add_after(Node Root)
        {
            int new_data = input_angka();
            Console.Write("setelah angka : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Root = queue.Add_after(Root, a, new_data);
            Console.WriteLine();
            return Root;
        }

        public override void Show(Node Root)
        {
            queue.Print_list(Root);
            Console.WriteLine();
        }

        public override Node Pop(Node Root)
        {
            Root = queue.Pop(Root);
            Console.WriteLine();
            return Root;
        }
    }
}
