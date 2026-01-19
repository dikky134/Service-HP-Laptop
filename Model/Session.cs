using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Model.Session
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static int PelangganId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
            PelangganId = 0;
        }
    }
}
