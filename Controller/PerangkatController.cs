using AplikasiService.Model.Entity;
using AplikasiService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Controller
{
    public class PerangkatController
    {
        PerangkatRepository repo = new PerangkatRepository();

        // SIMPAN PERANGKAT
        public void Insert(Perangkat perangkat)
        {
            repo.Insert(perangkat);
        }

        // TAMPILKAN PERANGKAT MILIK PELANGGAN
        public List<Perangkat> GetByPelanggan(int pelangganId)
        {
            return repo.GetByPelanggan(pelangganId);
        }
    }
}
