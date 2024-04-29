/*
 * Nama  : Achmad Luthfan Aufar Hindami
 * NPM   : 2120101669
 * Kelas : III RPLK
*/

using Quiz1;

// Inisialisasi data produk
List<Produk> daftarProduk =
            [
                new ("Kemeja Biru", 80000, 10),
                new ("Kaos Loreng", 50000, 15),
                new ("Kemeja Denim", 200000, 5),
                new ("Kaos Polo Hitam", 90000, 7),
                new ("Kemeja Garis Horizontal", 120000, 13),
                new ("Gamis Bunga Melati", 75000, 20),
                new ("Kaos Jersey Arema", 150000, 3),
                new ("Kemeja Abu", 80000, 14)
            ];

// Inisialisasi user
User admin = new User("admin", "1234");

// Login
Console.WriteLine("========== Aplikasi Toko Baju WOW ==========");
Console.Write("Username: ");
string username = Console.ReadLine();
Console.Write("Password: ");
string password = Console.ReadLine();

if (admin.Login(username, password))
{
    bool isRunning = true;
    while (isRunning)
    {
        // Menu utama
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Cari Produk");
        Console.WriteLine("2. Lihat Daftar Produk");
        Console.WriteLine("3. Tambah Produk");
        Console.WriteLine("4. Hapus Produk");
        Console.WriteLine("5. Keluar");
        Console.Write("Pilih menu: ");
        string pilihanMenu = Console.ReadLine();

        switch (pilihanMenu)
        {
            case "1":
                // Cari Produk
                Console.Write("Masukkan nama produk: ");
                string namaCari = Console.ReadLine();
                Console.Write("Masukkan harga minimum: ");
                double minHarga = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan harga maksimum: ");
                double maxHarga = Convert.ToDouble(Console.ReadLine());

                var produkDitemukan = daftarProduk.Where(x => x.Nama.Contains(namaCari, StringComparison.CurrentCultureIgnoreCase) && x.Harga >= minHarga && x.Harga <= maxHarga);
                Console.WriteLine("\nHasil Pencarian:");

                if (produkDitemukan.Any())
                {
                    foreach (var produk in produkDitemukan)
                    {
                        Console.WriteLine("-----------------------------------------------");
                        produk.TampilkanProduk();
                        Console.WriteLine("-----------------------------------------------");
                    }

                    Console.WriteLine("Sortir Produk berdasarkan Stok? (Y/N)");
                    char ifSortir = Console.ReadLine().ToLower()[0];

                    if (ifSortir == 'y')
                    {
                        Console.WriteLine("Pilih Metode Sortir");
                        Console.WriteLine("1. Ascending");
                        Console.WriteLine("2. Descending");

                        string pilihanSortir = Console.ReadLine();

                        var produkDitemukanSortir = produkDitemukan.OrderBy(x => x.Stok);

                        switch (pilihanSortir)
                        {
                            case "1":
                                produkDitemukanSortir = produkDitemukan.OrderBy(x => x.Stok);
                                break;

                            case "2":
                                produkDitemukanSortir = produkDitemukan.OrderByDescending(x => x.Stok);
                                break;

                            default:
                                Console.WriteLine("Pilihan tidak valid!");
                               break;
                        }

                        Console.WriteLine("Produk diurutkan:");
                        foreach (var produk in produkDitemukanSortir)
                        {
                            Console.WriteLine("-----------------------------------------------");
                            produk.TampilkanProduk();
                            Console.WriteLine("-----------------------------------------------");
                        }
                    }
                } else { Console.WriteLine("Maaf, produk tersebut tidak ditemukan!"); }
                

                break;

            case "2":
                // Sortir Produk
                Console.WriteLine("Pilih Metode Sortir");
                Console.WriteLine("1. Ascending");
                Console.WriteLine("2. Descending");
                var produkSortir = daftarProduk.OrderByDescending(x => x.Stok);

                string pilihanSortirAll = Console.ReadLine();
                switch (pilihanSortirAll)
                {
                    case "1":
                        produkSortir = daftarProduk.OrderBy(x => x.Stok);
                        Console.WriteLine("\nProduk diurutkan secara ascending berdasarkan jumlah stok:");
                        break;

                    case "2":
                        produkSortir = daftarProduk.OrderByDescending(x => x.Stok);
                        Console.WriteLine("\nProduk diurutkan secara descending berdasarkan jumlah stok:");
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }

                // Menampilkan produk yang sudah diurutkan
                foreach (var produk in produkSortir)
                {
                    Console.WriteLine("-----------------------------------------------");
                    produk.TampilkanProduk();
                    Console.WriteLine("-----------------------------------------------");
                }
                break;

            case "3":
                // Tambah Produk
                Console.Write("Masukkan nama produk baru: ");
                string namaBaru = Console.ReadLine();
                Console.Write("Masukkan harga produk baru: ");
                double hargaBaru = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan jumlah stok produk baru: ");
                int stokBaru = Convert.ToInt32(Console.ReadLine());

                daftarProduk.Add(new Produk(namaBaru, hargaBaru, stokBaru));
                Console.WriteLine("Produk berhasil ditambahkan!");
                break;

            case "4":
                // Hapus Produk
                Console.Write("Masukkan nama produk yang akan dihapus: ");
                string namaHapus = Console.ReadLine();
                var produkHapus = daftarProduk.FirstOrDefault(x => x.Nama.Equals(namaHapus, StringComparison.CurrentCultureIgnoreCase));
                if (produkHapus != null)
                {
                    daftarProduk.Remove(produkHapus);
                    Console.WriteLine("Produk berhasil dihapus!");
                }
                else
                {
                    Console.WriteLine("Produk tidak ditemukan!");
                }
                break;

            case "5":
                // Keluar
                Console.WriteLine("Terima kasih atas Kunjungannya!");
                isRunning = false;
                break;

            default:
                Console.WriteLine("Menu tidak valid!");
                break;
        }
    }
}
else
{
    Console.WriteLine("Username atau password salah!");
}
