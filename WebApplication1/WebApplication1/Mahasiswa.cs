namespace WebApplication1
{
    public class Mahasiswa
    {
        // Properti Nama
        public string Nama { get; set; }

        // Properti Nim
        public string Nim { get; set; }

        // Konstruktor untuk menginisialisasi properti Nama dan Nim
        public Mahasiswa(string nama, string nim)
        {
            Nama = nama;
            Nim = nim;
        }

        // Metode atau properti tambahan lainnya sesuai kebutuhan
        public void TampilkanInformasi()
        {
            Console.WriteLine($"Nama: {Nama}, NIM: {Nim}");
        }
    }
}
