using Backing.Data;
using Backing.Models;
using Backing.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backing.Repository
{
    public class PrecioCriptoRepository : IPrecioCriptoRepository, IDisposable
    {
        public readonly DatabaseContext dbContext;

        public PrecioCriptoRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// GetListAll: Toda la lista de precios de criptomonedas
        /// </summary>
        /// <returns></returns>
        public List<PrecioCripto> GetListAll()
        {
            try
            {
                return dbContext.PrecioCripto.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetById: Traer solo un precio de cripto por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PrecioCripto GetByID(int id)
        {
            return dbContext.Set<PrecioCripto>().Find(id);
        }

        /// <summary>
        /// Add: Agregar un precio de cripto
        /// </summary>
        /// <param name="precioCripto"></param>
        public void Add(PrecioCripto precioCripto)
        {
            try
            {
                dbContext.PrecioCripto.Add(precioCripto);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update: Actualiza un precio de cripto
        /// </summary>
        /// <param name="precioCripto"></param>
        public void Update(PrecioCripto precioCripto)
        {
            try
            {
                dbContext.Entry(precioCripto).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete: Eliminar un precio de cripto
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                PrecioCripto? precioCripto = dbContext.PrecioCripto.Find(id);

                if (precioCripto != null)
                {
                    dbContext.PrecioCripto.Remove(precioCripto);
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
        /// GetByCriptoAndMonedaAndFecha: Busca un precio por CrmId, MonId y fecha/hora exacta
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <param name="fechaHora"></param>
        /// <returns></returns>
        public PrecioCripto GetByCriptoAndMonedaAndFecha(int crmId, int monId, DateTime fechaHora)
        {

            DateTime fechaBusqueda = new DateTime(fechaHora.Year, fechaHora.Month, fechaHora.Day); // Año, Mes, Día

            return dbContext.PrecioCripto
                .FirstOrDefault(p => p.CrmId == crmId && p.MonId == monId && p.PrcPrecioFecha == fechaBusqueda);
        }

        /// <summary>
        /// GetByCriptoAndMoneda: Listar los registros por criptos y moneda
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        public List<PrecioCripto> GetByCriptoAndMoneda(int crmId, int monId)
        {
            try
            {
                return dbContext.PrecioCripto
                    .Where(c=>c.CrmId == crmId && c.MonId == monId)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetByCriptoAndMonedaDetalle: Listar los registros por criptos y moneda en detalle
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        public List<CriptosDTO> GetByCriptoAndMonedaDetalle(int crmId, int monId)
        {
            try
            {

                return dbContext.PrecioCripto 
                    .Where(p => p.CrmId == crmId && p.MonId == monId) 
                    .Select(p => new CriptosDTO
                    {        
                        PrcId = p.PrcId,
                        CrmId = p.CrmId,
                        CrmNombre = p.CriptoMoneda.CrmNombre,     
                        CrmSimbolo = p.CriptoMoneda.CrmSimbolo,   
                        MonId = p.MonId,
                        MonSimbolo = p.Moneda.MonSimbolo,         
                        MonNombre = p.Moneda.MonNombre,           
                        PrcPrecio = p.PrcPrecio,
                        PrcPrecioFecha = p.PrcPrecioFecha
                    })
                    .ToList();
                //return datos;

                //return dbContext.PrecioCripto
                //    .Where(c => c.CrmId == crmId && c.MonId == monId)
                //    .ToList();
            }
            catch
            {
                throw;
            }
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
