using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_us_pemograman_lanjut
{
    class Program
    {
        static proses proses = new proses();
        static void Main(string[] args)
        {
            while (true)
            {
                string username = null, password = null, email = null;
                long saldo = 0;
                Console.Clear();
                Tampil_login();
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Menu Login\n\nMasukkan Username : ");
                        username = Console.ReadLine();
                        Console.Write("Masukkan Password : ");
                        password = proses.Input_Password();
                        bool jawaban = proses.Login(username, password);
                        if(jawaban)
                        {
                            menu_pengguna();
                        }
                        else
                        {
                            Console.Write("\n Gagal login, username/password salah\npress any key to exit");
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Menu Daftar Baru\n\nMasukkan Username : ");
                            username = Console.ReadLine();
                            Console.Write("Masukkan Password : ");
                            password = proses.Input_Password();
                            Console.Write("\nMasukkan Email : ");
                            email = Console.ReadLine();
                            bool tempo = proses.check_email(email);
                            if (tempo)
                            {
                                break;
                            }
                        }
                        Console.Write("Masukkan Saldo Awal : ");
                        saldo = Convert.ToInt64(Console.ReadLine());
                        proses.daftar(username, password, email, saldo);
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Menu Recovery Password\n\nMasukkan email : ");
                        email = Console.ReadLine();
                        string reco_pass = proses.Recover_Password(email);
                        if(reco_pass == "")
                        {
                            Console.Write("Email salah\npress any key to exit");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("password : {0}\n\nubah password[y/n] : ", reco_pass);
                            string pil = Console.ReadLine();
                            if (pil.ToUpper() == "Y")
                            {
                                Console.Clear(); 
                                Console.Write("Password baru : ");
                                password = proses.Input_Password();
                                proses.ubah_password(password);
                                Console.Write("\n\npassword berhasil dirubah \npress any key to exit");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
            }
        }
        
        static void Tampil_login()
        {
            Console.Write("Sistem Bank Sederhana\n\n1. Login\n2. Mendaftar\n3. Recover akun\n4. keluar\npilihan : ");
        }

        static void menu_pengguna()
        {
            while (true)
            {
                long saldo = 0;
                Console.Clear();
                Console.Write("Menu Pengguna\n\n1. Tarik saldo\n2. Tambah saldo\n3. Tabungan\n4. Transfer\n5. Keterangan akun\n6. Logout\npilihan : ");
                int pilihan = Convert.ToInt32(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Menu Penarikan Saldo\n\nmasukkan Saldo : ");
                        saldo += Convert.ToInt64(Console.ReadLine());
                        proses.Proses_saldo(3, saldo);
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Menu Penambahan Saldo\n\ntambah saldo : ");
                        saldo += Convert.ToInt64(Console.ReadLine());
                        proses.Proses_saldo(1, saldo);
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Menu Tabungan\n\n1. Tambah tabungan\n2. Tarik tabungan\npilihan : ");
                        int temporary = Convert.ToInt32(Console.ReadLine());
                        switch (temporary)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("Menu Penambahan Tabungan\n\nTambah tabungan : ");
                                saldo = Convert.ToInt64(Console.ReadLine());
                                proses.Proses_saldo(2, saldo);
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("Menu Tarik Tabungan\n\nTarik tabungan : ");
                                saldo = Convert.ToInt64(Console.ReadLine());
                                proses.Proses_saldo(4, saldo);
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Menu Transfer\n\n1. Menggunakan pin\n2. Menggunakan username\npilihan : ");
                        int tempor = Convert.ToInt32(Console.ReadLine());
                        switch (tempor)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("Menu Transfer Menggunakan Pin\n\nMasukkan pin : ");
                                string pin = Console.ReadLine();
                                Console.Write("Masukkan jumlah saldo : ");
                                saldo += Convert.ToInt64(Console.ReadLine());
                                proses.Transfer(null, pin, saldo);
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("Menu Transfer Menggunakan Username\n\nMasukkan username : ");
                                string username = Console.ReadLine();
                                Console.Write("Masukkan jumlah saldo : ");
                                saldo += Convert.ToInt64(Console.ReadLine());
                                proses.Transfer(username, null, saldo);
                                break;
                        }
                        break;
                    case 5:
                        Console.Clear();
                        proses.Detail_akun();
                        break;
                    case 6:
                        proses.Logout();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
