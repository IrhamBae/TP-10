using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Daftar mahasiswa sebagai data penyimpanan sementara
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa("Budi", "123456"),
            new Mahasiswa("Siti", "654321")
        };

        // Endpoint untuk mendapatkan daftar semua mahasiswa
        [HttpGet]
        public IActionResult GetMahasiswa()
        {
            return Ok(mahasiswaList);
        }

        // Endpoint untuk mendapatkan mahasiswa berdasarkan NIM
        [HttpGet("{nim}")]
        public IActionResult GetMahasiswaByNim(string nim)
        {
            var mahasiswa = mahasiswaList.Find(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return Ok(mahasiswa);
        }

        // Endpoint untuk menambahkan mahasiswa baru
        [HttpPost]
        public IActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            mahasiswaList.Add(newMahasiswa);
            return CreatedAtAction(nameof(GetMahasiswaByNim), new { nim = newMahasiswa.Nim }, newMahasiswa);
        }

        // Endpoint untuk memperbarui data mahasiswa
        [HttpPut("{nim}")]
        public IActionResult UpdateMahasiswa(string nim, [FromBody] Mahasiswa updatedMahasiswa)
        {
            var mahasiswa = mahasiswaList.Find(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            mahasiswa.Nama = updatedMahasiswa.Nama;
            mahasiswa.Nim = updatedMahasiswa.Nim;
            return NoContent();
        }

        // Endpoint untuk menghapus mahasiswa
        [HttpDelete("{nim}")]
        public IActionResult DeleteMahasiswa(string nim)
        {
            var mahasiswa = mahasiswaList.Find(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            mahasiswaList.Remove(mahasiswa);
            return NoContent();
        }
    }
}
