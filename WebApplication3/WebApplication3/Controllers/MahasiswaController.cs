using Microsoft.AspNetCore.Mvc;
using MahasiswaAPI.Models;
using System.Collections.Generic;

namespace MahasiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa("Budi", "123456"),
            new Mahasiswa("Siti", "654321"),
        };

        [HttpGet]
        public ActionResult<List<Mahasiswa>> GetMahasiswa()
        {
            return mahasiswaList;
        }

        [HttpGet("{nim}")]
        public ActionResult<Mahasiswa> GetMahasiswa(string nim)
        {
            Mahasiswa mahasiswa = mahasiswaList.Find(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return mahasiswa;
        }

        [HttpPost]
        public ActionResult PostMahasiswa(Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(GetMahasiswa), new { nim = mahasiswa.Nim }, mahasiswa);
        }

        [HttpPut("{nim}")]
        public ActionResult PutMahasiswa(string nim, Mahasiswa updatedMahasiswa)
        {
            Mahasiswa mahasiswa = mahasiswaList.Find(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            mahasiswa.Nama = updatedMahasiswa.Nama;
            mahasiswa.Nim = updatedMahasiswa.Nim;
            return NoContent();
        }

        [HttpDelete("{nim}")]
        public ActionResult DeleteMahasiswa(string nim)
        {
            Mahasiswa mahasiswa = mahasiswaList.Find(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            mahasiswaList.Remove(mahasiswa);
            return NoContent();
        }
    }
}
