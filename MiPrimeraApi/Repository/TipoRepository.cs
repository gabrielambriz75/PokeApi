using MiPrimeraApi.Infrastructure;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Repository
{
    public class TipoRepository : ITipoRepository
    {
        private readonly CatalogoDbContext _bdContext;

        public TipoRepository(CatalogoDbContext bdContext)
        {
            _bdContext = bdContext;
        }

        public int CreateTipo(Tipo DatosTipo)
        {
            _bdContext.Add(DatosTipo);
            _bdContext.SaveChanges();

            return DatosTipo.IdTipo;
            throw new NotImplementedException();
        }

        public bool DeleteTipo(int IdTipo)
        {

            var item = _bdContext.Tipo.Where(x => x.IdTipo == IdTipo).FirstOrDefault();
            _bdContext.Remove(item);
            _bdContext.SaveChanges();
            return true;
            throw new NotImplementedException();
        }

        public bool ExistsTipo(string Descripcion)
        {
            return _bdContext.Tipo.Any(x => x.Descripcion.ToUpper() == Descripcion.ToUpper());
            throw new NotImplementedException();
        }

        public ICollection<Tipo> GetTipo()
        {
            return _bdContext.Tipo.ToList();
            throw new NotImplementedException();
        }

        public Tipo GetTipo(int IdTipo)
        {
            return _bdContext.Tipo.Where(x => x.IdTipo == IdTipo).FirstOrDefault();

            throw new NotImplementedException();
        }

        public Tipo UpdateTipo(Tipo DatosTipo)
        {
            var item = _bdContext.Tipo.Where(x => x.IdTipo == DatosTipo.IdTipo).FirstOrDefault();

            item.Descripcion = DatosTipo.Descripcion;
            item.FechaModifico = DateTime.Now;
            item.IdUModifico = DatosTipo.IdUModifico;
            _bdContext.SaveChanges();

            return _bdContext.Tipo.Where(x => x.IdTipo == DatosTipo.IdTipo).FirstOrDefault();
            throw new NotImplementedException();
        }
    }
}
