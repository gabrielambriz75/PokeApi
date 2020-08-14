using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        int CreateCategoria(Categoria DatosCategoria);

        ICollection<int> CreateCategoria(ICollection<Categoria> DatosCategoria);

        bool ExisteCategoria(string Nombre);
        bool DeleteCategoria(int Id);
        Categoria UpdateCategoria(Categoria DatosCategoria);
        ICollection<Categoria> UpdateCategoria(ICollection<Categoria> DatosCategoria);

    }
}
