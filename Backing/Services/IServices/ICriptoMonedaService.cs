using Backing.Data;
using Backing.Models;
using System.Collections;

namespace Backing.Services.IServices
{
    public interface ICriptoMonedaService
    {
        /// <summary>
        /// GetAll: Traer toda la lista de criptomonedas
        /// </summary>
        /// <returns></returns>
        IEnumerable GetAll();

        /// <summary>
        /// GetById: Buscar solo una criptomoneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CriptoMoneda GetById(int id);

        /// <summary>
        /// AddCriptoMoneda: Agregar una criptomoneda
        /// </summary>
        /// <param name="criptoMonedaModel"></param>
        /// <returns></returns>
        string AddCriptoMoneda(CriptoMonedaModel criptoMonedaModel);

        /// <summary>
        /// UpdateCriptoMoneda: Actualiza la criptomoneda
        /// </summary>
        /// <param name="criptoMonedaModel"></param>
        /// <returns></returns>
        string UpdateCriptoMoneda(CriptoMonedaModel criptoMonedaModel);

        /// <summary>
        /// DeleteCriptoMoneda: Eliminar una criptomoneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string DeleteCriptoMoneda(int id);

        /// <summary>
        /// GetCriptoMoneda: Buscar datos de la criptomoneda por nombre y símbolo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="simbolo"></param>
        /// <returns></returns>
        CriptoMoneda GetCriptoMoneda(string nombre, string simbolo);
    }
}
