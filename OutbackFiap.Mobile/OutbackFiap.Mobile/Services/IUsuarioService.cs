using System;
using System.Collections.Generic;
using System.Text;
using OutbackFiap.Mobile.Models;

namespace OutbackFiap.Mobile.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        bool Login(string email, string senha);
        Usuario GetByEmail(string email);
    }
}
