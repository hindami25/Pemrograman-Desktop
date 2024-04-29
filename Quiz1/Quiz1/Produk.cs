using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1
{
    internal class Produk
    {
        public string Nama { get; set; }
        public double Harga { get; set; }
        public int Stok { get; set; }

        public Produk(string nama, double harga, int stok)
        {
            Nama = nama;
            Harga = harga;
            Stok = stok;
        }

        public void TampilkanProduk()
        {
            Console.WriteLine("Nama Produk  : " + Nama);
            Console.WriteLine("Harga        : " + Harga);
            Console.WriteLine("Stok         : " + Stok);
        }
    }
}
