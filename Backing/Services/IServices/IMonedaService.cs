using Backing.Data;
using Backing.Models;
using System.Collections;

namespace Backing.Services.IServices
{
    public interface IMonedaService
    {
        /// <summary>
        /// GetAll: Traer toda la lista de monedas
        /// </summary>
        /// <returns></returns>
        IEnumerable GetAll();

        /// <summary>
        /// GetById: Buscar solo una moneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Moneda GetById(int id);

        /// <summary>
        /// AddMoneda: Agregar una moneda
        /// </summary>
        /// <param name="monedaModel"></param>
        /// <returns></returns>
        string AddMoneda(MonedaModel monedaModel);

        /// <summary>
        /// UpdateMoneda: Actualiza la moneda
        /// </summary>
        /// <param name="monedaModel"></param>
        /// <returns></returns>
        string UpdateMoneda(MonedaModel monedaModel);

        /// <summary>
        /// DeleteMoneda: Eliminar una moneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string DeleteMoneda(int id);
    }
}
