using Backing.Data;
using Backing.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backing.Repository
{
    public class MonedaRepository : IMonedaRepository, IDisposable
    {
        public readonly DatabaseContext dbContext;

        public MonedaRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// GetListAll: Traer lista de registros
        /// </summary>
        /// <returns></returns>
        public List<Moneda> GetListAll()
        {
            try
            {
                return dbContext.Moneda.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetByID: Buscar datos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Moneda GetByID(int id)
        {
            return dbContext.Set<Moneda>().Find(id);
        }

        /// <summary>
        /// Add: Agregar registro
        /// </summary>
        /// <param name="moneda"></param>
        public void Add(Moneda moneda)
        {
            try
            {
                dbContext.Moneda.Add(moneda);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update: Actualizar registro
        /// </summary>
        /// <param name="moneda"></param>
        public void Update(Moneda moneda)
        {
            try
            {
                dbContext.Entry(moneda).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete: Eliminar registro
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                Moneda? moneda = dbContext.Moneda.Find(id);

                if (moneda != null)
                {
                    dbContext.Moneda.Remove(moneda);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
