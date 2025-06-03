using Backing.Data;
using Backing.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backing.Repository
{
    public class CriptoMonedaRepository : ICriptoMonedaRepository, IDisposable
    {
        public readonly DatabaseContext dbContext;

        public CriptoMonedaRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// GetListAll: Toda la lista de criptomonedas
        /// </summary>
        /// <returns></returns>
        public List<CriptoMoneda> GetListAll()
        {
            try
            {
                return dbContext.CriptoMoneda.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetById: Traer solo una criptomoneda por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CriptoMoneda GetByID(int id)
        {
            return dbContext.Set<CriptoMoneda>().Find(id);
        }

        /// <summary>
        /// Add: Agregar una criptomoneda
        /// </summary>
        /// <param name="criptoMoneda"></param>
        public void Add(CriptoMoneda criptoMoneda)
        {
            try
            {
                dbContext.CriptoMoneda.Add(criptoMoneda);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update: Actualiza una criptomoneda
        /// </summary>
        /// <param name="criptoMoneda"></param>
        public void Update(CriptoMoneda criptoMoneda)
        {
            try
            {
                dbContext.Entry(criptoMoneda).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete: Eliminar una criptomoneda
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                CriptoMoneda? criptoMoneda = dbContext.CriptoMoneda.Find(id);

                if (criptoMoneda != null)
                {
                    dbContext.CriptoMoneda.Remove(criptoMoneda);
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

        /// <summary>
        /// GetByNameAndSymbol: Busca una criptomoneda por nombre y símbolo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="simbolo"></param>
        /// <returns></returns>
        public CriptoMoneda GetByNameAndSymbol(string nombre, string simbolo)
        {
            return dbContext.CriptoMoneda
                .FirstOrDefault(c => c.CrmNombre == nombre && c.CrmSimbolo == simbolo);
        }

        /// <summary>
        /// Guardar los cambios realizados
        /// </summary>
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
