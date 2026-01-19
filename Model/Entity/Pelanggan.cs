using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Model.Entity
{
    public class Pelanggan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
    }
}
