using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_baru
{
    class Program
    {
        static void Main(string[] args)
        {
            Nilai Murid1 = new Nilai("19.13.2257", 90.2, 72.3, 74.3);
            Nilai Murid2 = new Nilai("19.12.3321", 99.5, 14.3, 22.4);
            List < Nilai > list = new List<Nilai>();
            list.Add(Murid1);
            list.Add(Murid2);

            Nilai tampil1 = list[0];
            Nilai tampil2 = list[1];
            Console.WriteLine("nilai murid 1:");
            tampil1.tampil();
            Console.WriteLine();
            Console.WriteLine("nilai murid 2:");
            tampil2.tampil();
            Console.ReadKey();
        }
    }
}
