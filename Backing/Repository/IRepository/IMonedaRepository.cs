using Backing.Data;
using System;
using System.Collections.Generic;

namespace Backing.Repository.IRepository
{
    public interface IMonedaRepository : IDisposable
    {
        /// <summary>
        /// GetListAll: Traer lista de registros
        /// </summary>
        /// <returns></returns>
        List<Moneda> GetListAll();

        /// <summary>
        /// GetByID: Buscar datos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Moneda GetByID(int id);

        /// <summary>
        /// Add: Agregar registro
        /// </summary>
        /// <param name="moneda"></param>
        void Add(Moneda moneda);

        /// <summary>
        /// Update: Actualizar registro
        /// </summary>
        /// <param name="moneda"></param>
        void Update(Moneda moneda);

        /// <summary>
        /// Delete: Eliminar registro
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        void Save();
    }
}
