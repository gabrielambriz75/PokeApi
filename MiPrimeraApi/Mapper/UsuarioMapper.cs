using MiPrimeraApi.DTO;
using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MiPrimeraApi.Mapper
{
    public class UsuarioMapper:Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
