using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Repository.IRepository
{
    public interface IUsuarioRepository
    {
       

        ICollection<Usuario> GetUsuarios();
        int CreateUsuario(Usuario DatosUsuario,string password);
        bool ExisteUsuario(string UsuarioClientID);
        bool ExisteUsuario(int IdUsuario);
        Usuario Login(string Correo, string Contrasena);   
        Usuario GetUsuario(string Correo);

        Usuario GetUsuario(int IdUsuario);
    }
}
