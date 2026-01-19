using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Model.Entity
{
    public class Servis
    {
        public int Id { get; set; }
        public string Perangkat { get; set; }
        public string JenisKerusakan { get; set; }
        public string Status { get; set; }
        public int Biaya { get; set; }

    }
}
