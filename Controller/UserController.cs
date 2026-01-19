using AplikasiService.Model.Entity;
using AplikasiService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Controller
{
    public class UserController
    {
        UserRepository repo = new UserRepository();

        // LOGIN
        public User Login(string username, string password)
        {
            return repo.Login(username, password);
        }

        // BUAT USER (DIGUNAKAN SAAT SIGN UP)
        public int Insert(User user)
        {
            return repo.Insert(user);
        }
    }
}
