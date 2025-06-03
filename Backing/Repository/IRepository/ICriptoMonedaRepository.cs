using Backing.Data;
using System;
using System.Collections.Generic;

namespace Backing.Repository.IRepository
{
    public interface ICriptoMonedaRepository : IDisposable
    {
        /// <summary>
        /// GetListAll: Toda la lista de criptomonedas
        /// </summary>
        /// <returns></returns>
        List<CriptoMoneda> GetListAll();

        /// <summary>
        /// GetById: Traer solo una criptomoneda por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CriptoMoneda GetByID(int id);

        /// <summary>
        /// Add: Agregar una criptomoneda
        /// </summary>
        /// <param name="criptoMoneda"></param>
        void Add(CriptoMoneda criptoMoneda);

        /// <summary>
        /// Update: Actualiza una criptomoneda
        /// </summary>
        /// <param name="criptoMoneda"></param>
        void Update(CriptoMoneda criptoMoneda);

        /// <summary>
        /// Delete: Eliminar una criptomoneda
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// GetByNameAndSymbol: Busca una criptomoneda por nombre y símbolo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="simbolo"></param>
        /// <returns></returns>
        CriptoMoneda GetByNameAndSymbol(string nombre, string simbolo);

        /// <summary>
        /// Guardar los cambios realizados
        /// </summary>
        void Save();
    }
}
