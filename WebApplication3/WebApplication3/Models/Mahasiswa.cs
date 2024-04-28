namespace MahasiswaAPI.Models
{
    public class Mahasiswa
    {
        public string Nama { get; set; }

        public string Nim { get; set; }

        public Mahasiswa(string nama, string nim)
        {
            Nama = nama;
            Nim = nim;
        }

        public void TampilkanInformasi()
        {
            Console.WriteLine($"Nama: {Nama}, NIM: {Nim}");
        }
    }
}
