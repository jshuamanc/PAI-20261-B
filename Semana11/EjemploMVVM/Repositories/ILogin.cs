using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploMVVM.Repositories
{
    interface ILogin
    {
        public bool ValidarUsuario(string username, string password);
    }
}
