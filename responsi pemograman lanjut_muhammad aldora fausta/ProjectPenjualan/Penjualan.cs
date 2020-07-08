using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPenjualan
{
    public class Penjualan
    {
        // PERINTAH: lengkapi property class penjualan, sesuai petunjuk soal
        public string Nota { set; get; }
        public string Tanggal { set; get; }
        public string Kostumer { set; get; }
        public string Jenis { set; get; }
        public long Jumlah { set; get; }
        public void gabung(string nota, string tanggal, string kostumer, string jenis, long jumlah)
        {
            Nota = nota;
            Tanggal = tanggal;
            Kostumer = kostumer;
            Jenis = jenis;
            Jumlah = jumlah;
        }
    }
}
