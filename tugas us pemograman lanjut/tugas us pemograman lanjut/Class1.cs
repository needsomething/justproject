using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_us_pemograman_lanjut
{
    abstract class data
    {
        public abstract string Ambil_data(int a);
        public abstract long Ambil_saldo();
        public abstract bool Ubah_data(int a, string temp,long saldo);
        public abstract void Gabung(string username,string password, string email, long saldo, string pin);
        public abstract bool check_saldo(int a,long saldo);
        public abstract bool Tabungan(int a,long saldo);
        public abstract long Ambil_tabungan();
    }

    interface IProses
    {
        void daftar(string username, string password, string email, long saldo);
        void Detail_akun();
        void Logout();
        string Input_Password();
        string Recover_Password(string email);
        string Generate_pin();
        void ubah_password(string password);
        bool Login(string username,string password);
        void Proses_saldo(int pilihan, long saldo);
        bool check_email(string email);
        void Transfer(string Username, string pin, long saldo);
    }

    class Akun : data
    {
        protected string Username { set; get; }
        protected string Password { set; get; }
        protected string Email { set; get; }
        protected string Pin { set; get; }
        protected long Jumlah_saldo { set; get; }
        protected long Isi_tabungan { set; get; } //variabel untuk isi tabungan
        public override void Gabung(string username, string password, string email, long saldo, string pin)
        {
            Username = username;
            Password = password;
            Email = email;
            Jumlah_saldo = saldo;
            Pin = pin;
        }

        public override string Ambil_data(int a)
        {
            string temp = "";
            switch (a)
            {
                case 1:
                    temp = Username;
                    break;
                case 2:
                    temp = Password;
                    break;
                case 3:
                    temp = Email;
                    break;
                case 4:
                    temp = Pin;
                    break;
            }
            return temp;
        }

        public override long Ambil_saldo()
        {
            long temp = Jumlah_saldo;
            return temp;
        }

        public override long Ambil_tabungan()
        {
            long temp = Isi_tabungan;
            return temp;
        }

        public override bool Ubah_data(int a, string temp,long saldo)
        {
            if (temp != null)
            {
                switch (a)
                {
                    case 1:
                        Username = temp;
                        break;
                    case 2:
                        Password = temp;
                        break;
                    case 3:
                        Email = temp;
                        break;
                }
            }
            else
            {
                switch (a)
                {
                    case 1:
                        if (check_saldo(1,saldo)) { Jumlah_saldo -= saldo; return true; } //tarik saldo
                        else { return false; }
                    case 2:
                        if (check_saldo(1,saldo)) { bool asal = Tabungan(2,saldo); Jumlah_saldo -= saldo; return true; } //masukkan ke tabungan
                        else { return false; }
                    case 3:
                        Jumlah_saldo += saldo; return true;//tambah saldo
                }
            }
            return true;
        }

        public override bool Tabungan(int a,long saldo)
        {
            switch (a)
            {
                case 1:
                    if (check_saldo(2, saldo)) {Jumlah_saldo += saldo; Isi_tabungan -= saldo; return true; } //tarik tabungan ke saldo 
                    else { return false; }
                case 2:
                    if (check_saldo(1, saldo)) { Isi_tabungan += saldo; return true; } //tambah tabungan
                    else { return false; }
            }
            return true;
        }

        public override bool check_saldo(int a,long saldo)
        {
            switch (a)
            {
                case 1:
                    long temp = Jumlah_saldo - saldo;
                    if (temp < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case 2:
                    long b = Isi_tabungan - saldo;
                    if (b < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
            }
            return true;
        }
    }

    class proses : IProses
    {
        List<Akun> Data_Akun = new List<Akun>();
        private int Login_status = -999;
        private int Antrian = 1;
        private int ubah_password_akun { set; get; }
        public void daftar(string username, string password, string email, long saldo)
        {
            Akun akun = new Akun();
            string temp = Generate_pin();
            akun.Gabung(username, password, email, saldo, temp);
            Data_Akun.Add(akun);
        }

        public bool check_email(string email)
        {
            for(int i = 0; i < Data_Akun.Count; i++)
            {
                Akun data = Data_Akun[i];
                if (data.Ambil_data(3) == email)
                {
                    return false;
                }
            }
            return true;
        }

        public void Detail_akun()
        {
            Akun data = Data_Akun[Login_status];
            Console.WriteLine("Detail Akun\nNama : {0}", data.Ambil_data(1));
            Console.WriteLine("Email : {0}", data.Ambil_data(3));
            Console.WriteLine("Pin : {0}", data.Ambil_data(4));
            Console.WriteLine("Saldo : {0}", data.Ambil_saldo());
            Console.WriteLine("Tabungan : {0}\nPress any key to exit", data.Ambil_tabungan());
            Console.ReadKey();
        }

        public string Recover_Password(string email)
        {
            for(int i = 0; i < Data_Akun.Count; i++)
            {
                Akun data = Data_Akun[i];
                if(data.Ambil_data(3) == email)
                {
                    ubah_password_akun = i;
                    return data.Ambil_data(2);
                }
            }
            return "";
        }

        public void Proses_saldo(int pilihan, long saldo)
        {
            Akun data = Data_Akun[Login_status];
            switch (pilihan)
            {
                case 1: //menambah jumlah saldo
                    if (data.Ubah_data(3, null, saldo)) { Console.Write("\nSaldo berhasil ditambahkan\nPress any key to exit\n"); Console.ReadKey(); }
                    break;
                case 2: //menambah isi tabungan
                    if (data.Ubah_data(2, null, saldo)) { Console.Write("\nTabungan berhasil ditambahkan\nPress any key to exit\n"); Console.ReadKey(); }
                    else { Console.Write("Saldo tak cukup, jumlah saldo {0}\nPress any key to exit\n", data.Ambil_saldo()); Console.ReadKey(); }
                    break;
                case 3: //tarik saldo
                    if (data.Ubah_data(1, null, saldo)) { Console.Write("\nUang senilai {0} berhasil ditarik, sisa saldo {1}\nPress any key to exit\n",saldo,data.Ambil_saldo()); Console.ReadKey(); }
                    else { Console.Write("\nSaldo kurang, sisa saldo {0}\npress any key to exit\n", data.Ambil_saldo()); Console.ReadKey(); }
                    break;
                case 4: //tarik tabungan ke saldo
                    if (data.Tabungan(1, saldo)) { Console.Write("\nSaldo senilai {0} berhasil ditarik dari tabungan, sisa tabungan {1}\npress any key to exit\n", saldo, data.Ambil_tabungan()); Console.ReadKey(); }
                    else { Console.Write("\nTabungan kurang, sisa tabungan {0}\nPress any key to exit\n", data.Ambil_tabungan()); Console.ReadKey(); }
                    break;
            }
        }

        public void Logout()
        {
            Login_status = -999;
        }

        public bool Login(string username, string password)
        {
            for(int i = 0; i < Data_Akun.Count; i++)
            {
                Akun login = Data_Akun[i];
                if(login.Ambil_data(1) == username && login.Ambil_data(2) == password)
                {
                    Login_status = i;
                    break;
                }
            }
            if(Login_status == -999)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Generate_pin()
        {
            DateTime date = DateTime.Now;
            string a = Convert.ToString(date);
            string b = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ')
                {
                    continue;
                }
                else if (a[i] == '/')
                {
                    continue;
                }
                else if (a[i] == ':')
                {
                    continue;
                }
                else if(a[i] == 'A' || a[i] == 'M' || a[i] == 'P')
                {
                    continue;
                }
                b += a[i];
            }
            b += Convert.ToString(Antrian);
            Antrian++;
            return b;
        }

        public string Input_Password()
        {
            string password = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length != 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if(key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return password;
        }

        public void Transfer(string Username ,string pin , long saldo)
        {
            Akun data = Data_Akun[Login_status];
            if(Username == null)
            {
                for(int i = 0; i < Data_Akun.Count; i++)
                {
                    Akun tempo = Data_Akun[i];
                    if(tempo.Ambil_data(4) == pin)
                    {
                        if (data.Ubah_data(1, null, saldo))
                        {
                            tempo.Ubah_data(3, null, saldo);
                            Console.Write("Saldo berhasil ditransfer\nPress any key to exit");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.Write("Saldo kurang, sisa saldo {0}\nPress any key to exit",tempo.Ambil_saldo());
                            Console.ReadKey();
                            return;
                        }
                    }
                }
                Console.Write("Pin tak ditemukan\nPress any key to exit\n");
                Console.ReadKey();
            }

            else
            {
                for (int i = 0; i < Data_Akun.Count; i++)
                {
                    Akun tempo = Data_Akun[i];
                    if (tempo.Ambil_data(1) == Username)
                    {
                        if (data.Ubah_data(1, null, saldo))
                        {
                            tempo.Ubah_data(3, null, saldo);
                            Console.Write("Saldo berhasil ditransfer\nPress any key to exit");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.Write("Saldo kurang, sisa saldo {0}\nPress any key to exit", tempo.Ambil_saldo());
                            Console.ReadKey();
                            return;
                        }
                    }
                }
                Console.Write("Username tak ditemukan\nPress any key to exit\n");
                Console.ReadKey();
            }
        }

        public void ubah_password(string password)
        {
            Akun data = Data_Akun[ubah_password_akun];
            data.Ubah_data(2, password, -1);
            ubah_password_akun = -999;
        }
    }
}