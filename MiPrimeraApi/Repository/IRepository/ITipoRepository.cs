using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Repository.IRepository
{
    interface ITipoRepository
    {
        ICollection<Tipo> GetTipo();
        Tipo GetTipo(int IdTipo);

        bool ExistsTipo(string Descripcion);

        int CreateTipo(Tipo DatosTipo);

        bool DeleteTipo(int IdTipo);

        Tipo UpdateTipo(Tipo DatosTipo);
    }
}
