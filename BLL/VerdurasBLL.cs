using Microsoft.EntityFrameworkCore;
using Parcial2_Frank.Models;
using Parcial2_Frank.Data;
using System.Linq.Expressions;

namespace Parcial2_Frank.BLL
{
    public class VerdurasBLL
    {
        public ApplicationDbContext _contexto;

        public VerdurasBLL(ApplicationDbContext context)
        {
            _contexto = context;
        }

        public bool Existe(int verduraId)
        {
            return _contexto.verduras.Any(v => v.VerdurasId == verduraId);
        }
        public bool Insertar (Verduras verdura)
        {
            _contexto.Entry(verdura).State = EntityState.Added;
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Verduras verdura)
        {
            _contexto.Entry(verdura).State = EntityState.Modified;
            return _contexto.SaveChanges () > 0;
        }

        public bool Guardar(Verduras verdura)
        {
            if(!Existe(verdura.VerdurasId))
                return this.Insertar(verdura);
            else
                return this.Modificar(verdura);
        }

        public bool Eliminar(Verduras verdura)
        {
            _contexto.Entry(verdura).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Verduras? Buscar(int verdurasId)
        {
            return _contexto.verduras
                .Where(v => v.VerdurasId == verdurasId)
                .Include(v => v.detalle)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<Verduras> GetList(Expression<Func<Verduras, bool>> Criterio)
        {
            return _contexto.verduras
                .AsNoTracking()
                .Where(Criterio)
                .Include(v => v.detalle)
                .ToList();
        }

    }
}
