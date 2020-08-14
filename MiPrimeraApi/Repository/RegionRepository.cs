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
    public class RegionRepository : IRegionRepository
    {
        private readonly CatalogoDbContext _bdContext;

        public RegionRepository(CatalogoDbContext bdContext)
        {
            _bdContext = bdContext;
        }

        public int CreateRegion(Region DatosRegion)
        {
            _bdContext.Add(DatosRegion);
            _bdContext.SaveChanges();

            return DatosRegion.IdRegion;
            throw new NotImplementedException();

        }

        public bool DeleteRegion(int IdRegion)
        {
            var item= _bdContext.Region.Where(x => x.IdRegion == IdRegion).FirstOrDefault();
            _bdContext.Remove(item);
            _bdContext.SaveChanges();
            return true;
            throw new NotImplementedException();
        }

        public bool ExistsRegion(string Nombre)
        {
            return _bdContext.Region.Any(x => x.Nombre.ToUpper() == Nombre.ToUpper());

            throw new NotImplementedException();
        }

        public ICollection<Region> GetRegion()
        {
            return _bdContext.Region.ToList();
            throw new NotImplementedException();
        }

        public Region GetRegion(int IdRegion)
        {

            return _bdContext.Region.Where(x=>x.IdRegion== IdRegion).FirstOrDefault();
            throw new NotImplementedException();
        }

        public Region UpdateRegion(Region DatosRegion)
        {
            var item = _bdContext.Region.Where(x => x.IdRegion == DatosRegion.IdRegion).FirstOrDefault();

            item.Nombre = DatosRegion.Nombre;
            item.Activo = DatosRegion.Activo;
            item.FechaModifico = DateTime.Now;
            item.IdUModifico = DatosRegion.IdUModifico;
            _bdContext.SaveChanges();
            return _bdContext.Region.Where(x => x.IdRegion == DatosRegion.IdRegion).FirstOrDefault();
            throw new NotImplementedException();
        }
    }
}
