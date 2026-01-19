using AplikasiService.Model.Entity;
using AplikasiService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Controller
{
    public class LoginController
    {
        UserRepository repo = new UserRepository();

        public User Login(string u, string p)
        {
            return repo.Login(u, p);
        }
    }
}
