using Microsoft.EntityFrameworkCore;
using Parcial2_Frank.Models;
using Parcial2_Frank.Data;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            return _contexto.verduras.Any(v => v.VerduraId == verduraId);
        }
        public bool Insertar(Verduras verdura)
        {
            _contexto.verduras.Add(verdura);
            _contexto.Entry(verdura).State = EntityState.Detached;
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Verduras verdura)
        {
            _contexto.Database.ExecuteSqlRaw($"Delete FROM VerdurasDetalle where and VerdurasId = {verdura.VerduraId}");

            foreach (var item in verdura.Detalle)
            {
                _contexto.Entry(item).State = EntityState.Added;
            }
            _contexto.Entry(verdura).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Verduras verdura)
        {
            var existe =  Existe(verdura.VerduraId);

            if (!existe)
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
                .Where(v => v.VerduraId == verdurasId)
                .Include(v => v.Detalle)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<Verduras> GetList(Expression<Func<Verduras, bool>> Criterio)
        {
            return _contexto.verduras
                .AsNoTracking()
                .Where(Criterio)
                .Include(v => v.Detalle)
                .ToList();
        }

        public List<Vitaminas> GetVitaminas(Expression<Func<Vitaminas, bool>> Criterio)
        {
            return _contexto.vitaminas
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

    }
}
