using AplikasiService.Model.Entity;
using AplikasiService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Controller
{
    public class ServiceController
    {
        ServisRepository repo = new ServisRepository();

        // TAMBAH DATA SERVIS
        public void Insert(Servis servis)
        {
            repo.Insert(servis);
        }

        // AMBIL SERVIS MILIK PELANGGAN
        public List<Servis> GetByPelanggan(int pelangganId)
        {
            return repo.GetByPelanggan(pelangganId);
        }
    }
}
