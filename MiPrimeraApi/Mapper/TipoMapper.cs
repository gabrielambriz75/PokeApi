﻿using AutoMapper;
using MiPrimeraApi.DTO;
using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Mapper
{
    public class TipoMapper:Profile
    {
        public TipoMapper()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
