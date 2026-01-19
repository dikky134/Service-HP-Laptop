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
        public int PerangkatId { get; set; }
        public int KerusakanId { get; set; }
        public string Status { get; set; }
        public int Biaya { get; set; }

    }
}
