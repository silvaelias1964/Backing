using Backing.Data;
using Backing.Models;
using Backing.Repository;
using System.Collections;

namespace Backing.Services.IServices
{
    public interface IPrecioCriptoService
    {
        /// <summary>
        /// GetAll: Traer toda la lista de precios de criptomonedas
        /// </summary>
        /// <returns></returns>
        IEnumerable GetAll();

        /// <summary>
        /// GetById: Buscar solo un precio de cripto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PrecioCripto GetById(int id);

        /// <summary>
        /// AddPrecioCripto: Agregar un precio de cripto
        /// </summary>
        /// <param name="precioCriptoModel"></param>
        /// <returns></returns>
        string AddPrecioCripto(PrecioCriptoModel precioCriptoModel);

        /// <summary>
        /// UpdatePrecioCripto: Actualiza el precio de cripto
        /// </summary>
        /// <param name="precioCriptoModel"></param>
        /// <returns></returns>
        string UpdatePrecioCripto(PrecioCriptoModel precioCriptoModel);

        /// <summary>
        /// DeletePrecioCripto: Eliminar un precio de cripto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string DeletePrecioCripto(int id);

        /// <summary>
        /// GetPrecioCripto: Buscar precio por CrmId, MonId y fecha/hora exacta
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <param name="fechaHora"></param>
        /// <returns></returns>
        PrecioCripto GetPrecioCripto(int crmId, int monId, DateTime fechaHora);

        /// <summary>
        /// GetPrecioCriptoMoneda: Listar registros de precios por criptos y moneda
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        IEnumerable GetPrecioCriptoMoneda(int crmId, int monId);

        /// <summary>
        /// GetPrecioCriptoMonedaDetalle: Listar registros de precios por criptos y moneda en detalle
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        IEnumerable GetPrecioCriptoMonedaDetalle(int crmId, int monId);

    }
}
