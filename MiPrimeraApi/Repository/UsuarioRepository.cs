using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Infrastructure;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MiPrimeraApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CatalogoDbContext _bdUsuario;
        public UsuarioRepository(CatalogoDbContext bdUsuario)
        {
            _bdUsuario = bdUsuario;
        }
        public int CreateUsuario(Usuario DatosUsuario)
        {
            _bdUsuario.Add(DatosUsuario);
            _bdUsuario.SaveChanges();

            return DatosUsuario.IdUsuario;
            
        }

      

        public bool ExisteUsuario(string Correo)
        {

            return _bdUsuario.Usuario.Any(x=>x.Correo == Correo);
            
        }

        public bool ExisteUsuario(int Id)
        {
            return _bdUsuario.Usuario.Any(x => x.IdUsuario == Id);
           
        }

        public Usuario GetUsuario(string Correo)
        {
            return _bdUsuario.Usuario.Where(x=>x.Correo ==Correo).FirstOrDefault();
         
        }

        public bool Login(string Correo, string Contrasena)
        {
            var ItemUsuario = _bdUsuario.Usuario.
                Where(x => x.Correo.Trim().ToUpper() == Correo.Trim().ToUpper()
                   && x.Contrasena == Contrasena).FirstOrDefault();

            return ItemUsuario == null ? false : true;
           
           
        }

       
    }
}
