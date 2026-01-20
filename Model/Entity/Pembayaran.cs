using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Model.Entity
{
    public class Pembayaran
    {
        public int Id { get; set; }
        public int ServisId { get; set; }
        public string TanggalBayar { get; set; }
        public string TanggalBuat { get; set; }
        public int Total { get; set; }
        public string Metode { get; set; }
        public string Status { get; set; }

    }
}
