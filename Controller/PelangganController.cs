using AplikasiService.Model.Context;
using AplikasiService.Model.Entity;
using AplikasiService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Controller
{
    public class PelangganController
    {
        public Pelanggan GetByUserId(int userId)
        {
            Pelanggan pelanggan;

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                PelangganRepository repo = new PelangganRepository(conn);
                pelanggan = repo.GetByUserId(userId);
            }

            return pelanggan;
        }
    }
}
