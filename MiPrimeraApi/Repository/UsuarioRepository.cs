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
        //public int CreateUsuario(Usuario DatosUsuario)
        //{
        //    _bdUsuario.Add(DatosUsuario);
        //    _bdUsuario.SaveChanges();

        //    return DatosUsuario.IdUsuario;
            
        //}

        public int CreateUsuario(Usuario DatosUsuario, string password)
        {
            try
            {
                byte[] HashPassword, SaltPassword;
                Criptography.CrearPasswordEncriptado(password, out HashPassword, out SaltPassword);
                DatosUsuario.HashPassword = HashPassword;
                DatosUsuario.SaltPass = SaltPassword;

                _bdUsuario.Usuario.Add(DatosUsuario);
                _bdUsuario.SaveChanges();
                return DatosUsuario.IdUsuario;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
         

           
        }

        public ICollection<Usuario> GetUsuarios()
        {
            var ListUsuarios = _bdUsuario.Usuario.ToList();
            return ListUsuarios;
            throw new NotImplementedException();
        }
      
        public bool ExisteUsuario(string UsuarioClientID)
        {

            return _bdUsuario.Usuario.Any(x => x.ClientId == UsuarioClientID);
            
        }

        public bool ExisteUsuario(int Id)
        {
            return _bdUsuario.Usuario.Any(x => x.IdUsuario == Id);
           
        }

        public Usuario GetUsuario(string Correo)
        {
            return _bdUsuario.Usuario.Where(x=>x.Correo ==Correo).FirstOrDefault();
         
        }

      

        public Usuario Login(string ClientId, string Contrasena)
        {
            var usuarioCredencial = _bdUsuario.Usuario.Where(x => x.ClientId == ClientId).FirstOrDefault();

            if(usuarioCredencial == null)
            {
                return null;
            }

            if (!Criptography.ValidacionPassword(Contrasena, usuarioCredencial.HashPassword,usuarioCredencial.SaltPass))
            {
                return null;
            }

            return usuarioCredencial;
           
           
        }

        public Usuario GetUsuario(int IdUsuario)
        {
            return _bdUsuario.Usuario.Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();
            throw new NotImplementedException();
        }
    }
}
