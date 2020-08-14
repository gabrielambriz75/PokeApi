using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Repository.IRepository
{
    interface IRegionRepository
    {
        ICollection<Region> GetRegion();
        Region GetRegion(int IdRegion);

        bool ExistsRegion(string Nombre);

        int CreateRegion(Region DatosRegion);

        bool DeleteRegion(int IdRegion);

        Region UpdateRegion(Region DatosRegion);
    }
}
