using Backing.Data;
using Backing.Models;
using System;
using System.Collections.Generic;

namespace Backing.Repository.IRepository
{
    public interface IPrecioCriptoRepository : IDisposable
    {
        /// <summary>
        /// GetListAll: Toda la lista de precios de criptomonedas
        /// </summary>
        /// <returns></returns>
        List<PrecioCripto> GetListAll();

        /// <summary>
        /// GetById: Traer solo un precio de cripto por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PrecioCripto GetByID(int id);

        /// <summary>
        /// Add: Agregar un precio de cripto
        /// </summary>
        /// <param name="precioCripto"></param>
        void Add(PrecioCripto precioCripto);

        /// <summary>
        /// Update: Actualiza un precio de cripto
        /// </summary>
        /// <param name="precioCripto"></param>
        void Update(PrecioCripto precioCripto);

        /// <summary>
        /// Delete: Eliminar un precio de cripto
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// GetByCriptoAndMonedaAndFecha: Busca un precio por CrmId, MonId y fecha/hora exacta
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <param name="fechaHora"></param>
        /// <returns></returns>
        PrecioCripto GetByCriptoAndMonedaAndFecha(int crmId, int monId, DateTime fechaHora);

        /// <summary>
        /// GetByCriptoAndMoneda: Listar los registros por criptos y moneda
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        List<PrecioCripto> GetByCriptoAndMoneda(int crmId, int monId);

        /// <summary>
        /// GetByCriptoAndMonedaDetalle: Listar los registros por criptos y moneda en detalle
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        List<CriptosDTO> GetByCriptoAndMonedaDetalle(int crmId, int monId);

        /// <summary>
        /// Guardar los cambios realizados
        /// </summary>
        void Save();
    }
}
