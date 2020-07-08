using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPenjualan
{
    class Program
    {
        // deklarasi objek collection untuk menampung objek penjualan
        static List<Penjualan> daftarPenjualan = new List<Penjualan>();

        static void Main(string[] args)
        {
            Console.Title = "Responsi UAS Matakuliah Pemrograman";

            while (true)
            {
                TampilMenu();

                Console.Write("\nNomor Menu [1..5]: ");
                int nomorMenu = Convert.ToInt32(Console.ReadLine());

                switch (nomorMenu)
                {
                    case 1:
                        TambahPenjualan();
                        break;

                    case 2:
                        HapusPenjualan();
                        break;

                    case 3:
                        TampilPenjualan();
                        break;

                    case 4:
                        edit_penjualan();
                        break;

                    case 5: // keluar dari program
                        return;

                    default:
                        break;
                }
            }
        }

        static void TampilMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Tambah Penjualan\n2. Hapus Penjualan\n3. Tampilkan Penjualan\n4. Edit Data\n5. Keluar");
            // PERINTAH: lengkapi kode untuk menampilkan menu
        }

        static void TambahPenjualan()
        {
            Console.Clear();
            Penjualan data = new Penjualan();
            string jenis;
            // PERINTAH: lengkapi kode untuk menambahkan penjualan ke dalam collection
            Console.WriteLine("Tambah Data Penjualan\n");
            Console.Write("Nota: ");
            string nota = Console.ReadLine();
            Console.Write("Tanggal: ");
            string tanggal = Console.ReadLine();
            Console.Write("Customer: ");
            string customer = Console.ReadLine();
            Console.Write("Jenis [T/K]: ");
            jenis = Console.ReadLine();
            if (jenis.ToUpper() == "T")
            {
                jenis = "Tunai";
            }
            else if(jenis.ToUpper() == "K") 
            {
                jenis = "Kredit";
            }
            Console.Write("Total: ");
            long total = Convert.ToInt32(Console.ReadLine());
            data.gabung(nota, tanggal, customer, jenis, total);
            daftarPenjualan.Add(data);
            Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
            Console.ReadKey();
        }

        static void HapusPenjualan()
        {
            Console.Clear();

            // PERINTAH: lengkapi kode untuk menghapus penjualan dari dalam collection
            Console.WriteLine("Hapus Data Penjualan\n");
            Console.Write("Nota: ");
            string nota = Console.ReadLine();
            for(int i = 0; i < daftarPenjualan.Count(); i++)
            {
                Penjualan data = daftarPenjualan[i];
                if(nota == data.Nota)
                {
                    daftarPenjualan.RemoveAt(i);
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Data penjualan berhasil di hapus");
            Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
            Console.ReadKey();
            TampilPenjualan();
        }

        static void TampilPenjualan()
        {
            Console.Clear();

            // PERINTAH: lengkapi kode untuk menampilkan daftar penjualan yang ada di dalam collection
            Console.WriteLine("Data Penjualan\n");
            for(int i = 0; i < daftarPenjualan.Count(); i++)
            {
                Penjualan data = daftarPenjualan[i];
                Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}", (i + 1), data.Nota, data.Tanggal, data.Kostumer, data.Jenis, data.Jumlah);
            }

            Console.WriteLine("\nTekan enter untuk kembali ke menu");
            Console.ReadKey();
        }

        static void edit_penjualan()
        {
            Console.Clear();
            int pilihan;
            int temp = 0;
            Console.WriteLine("Ubah Data\n");
            Console.Write("nota: ");
            string nota = Console.ReadLine();
            for(int i = 0; i < daftarPenjualan.Count; i++)
            {
                Penjualan data = daftarPenjualan[i];
                if(data.Nota == nota)
                {
                    temp = i;
                    break;
                }
            }
            while (true)
            {
                Penjualan data = daftarPenjualan[temp];
                Console.Clear();
                Console.WriteLine("Edit Data\n");
                Console.WriteLine("");
                Console.WriteLine("1. Nota: {0}\n2. Tanggal: {1}\n3. Customer: {2}\n4. jenis: {3}\n5. Total Nota: {4}\n6. selesai\n", data.Nota, data.Tanggal, data.Kostumer, data.Jenis, data.Jumlah);
                Console.Write("\nEdit [1..6]: ");
                pilihan = Convert.ToInt32(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        Console.Write("Nota: ");
                        string Nota = Console.ReadLine();
                        data.Nota = Nota;
                        break;
                    case 2:
                        Console.Write("Tanggal: ");
                        string Tanggal = Console.ReadLine();
                        data.Tanggal = Tanggal;
                        break;
                    case 3:
                        Console.Write("Customer: ");
                        string customer = Console.ReadLine();
                        data.Kostumer = customer;
                        break;
                    case 4:
                        Console.Write("Jenis [T/K]: ");
                        string jenis = Console.ReadLine();
                        if(jenis.ToUpper() == "T")
                        {
                            data.Jenis = "Tunai";
                        }
                        else if(jenis.ToUpper() == "K")
                        {
                            data.Jenis = "Kredit";
                        }
                        break;
                    case 5:
                        Console.Write("Total Nota: ");
                        long total = Convert.ToInt32(Console.ReadLine());
                        data.Jumlah = total;
                        break;
                    case 6:
                        return;

                    default:
                        break;
                }
            }
            Console.WriteLine("\nTekan enter untuk kembali ke menu");
            Console.ReadKey();
        }
    }
}
