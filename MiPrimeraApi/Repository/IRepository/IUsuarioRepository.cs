using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        int CreateUsuario(Usuario DatosUsuario);
        bool ExisteUsuario(string Correo);
        bool ExisteUsuario(int Id);
        bool Login(string Correo, string Contrasena);
        Usuario GetUsuario(string Correo);

    }
}
