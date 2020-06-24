using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tugas_baru
{
    abstract class nilai
    {
        public abstract void tampil();
    }

    interface Ihasil
    {
        double hasil();
    }

    class Nilai : nilai, Ihasil
    {
        protected string Id_siswa { set; get; }
        protected double Nilai_pertama { set; get; }
        protected double Nilai_kedua { set; get; }
        protected double Nilai_ketiga { set; get; }
        public Nilai(string id_siswa, double nilai_pertama,double nilai_kedua,double nilai_ketiga)
        {
            Id_siswa = id_siswa;
            Nilai_pertama = nilai_pertama;
            Nilai_kedua = nilai_kedua;
            Nilai_ketiga = nilai_ketiga;
        }

        public double hasil()
        {
            double Hasil = (Nilai_pertama + Nilai_kedua + Nilai_ketiga) / 3;
            return Hasil;
        }

        public override void tampil()
        {
            Console.WriteLine("id murid \t: {0}", Id_siswa);
            Console.WriteLine("jumlah nilai\t: {0}", hasil());
        }

    }
}
