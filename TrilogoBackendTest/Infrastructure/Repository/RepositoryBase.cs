using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Repository
{
    public abstract class RepositoryBase<TObject> : IRepository<TObject> where TObject : class
    {
        protected readonly TrilogoContext _context;
        protected readonly IDbConnection _connectionRead;

        public RepositoryBase(TrilogoContext context)
        {
            _context = context;
            _connectionRead = context.ConnectionRead();
        }

        public void Apagar(TObject delete)
        {
            _context.Set<TObject>().Remove(delete);
            _context.SaveChanges();
        }

        public TObject Editar(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = _context.Set<TObject>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.SaveChanges();
            }
            return existing;
        }

        public TObject Incluir(TObject t)
        {
            _context.Set<TObject>().Add(t);
            _context.SaveChanges();
            return t;
        }

    }
}

