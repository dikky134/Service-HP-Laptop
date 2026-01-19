using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Model.Entity
{
    public class Perangkat
    {
        public int Id { get; set; }
        public int PelangganId { get; set; }
        public string Jenis { get; set; }
        public string Merk { get; set; }
        public string Tipe { get; set; }
    }
}
