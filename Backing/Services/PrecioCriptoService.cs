using Backing.Data;
using Backing.Models;
using Backing.Repository.IRepository;
using Backing.Services.IServices;
using System.Collections;

namespace Backing.Services
{
    public class PrecioCriptoService : IPrecioCriptoService
    {
        public readonly IPrecioCriptoRepository precioCriptoRepository;

        public PrecioCriptoService(IPrecioCriptoRepository precioCriptoRepository)
        {
            this.precioCriptoRepository = precioCriptoRepository;
        }

        /// <summary>
        /// GetAll: Traer toda la lista de precios de criptomonedas
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAll()
        {
            var datos = precioCriptoRepository.GetListAll();
            return datos;
        }

        /// <summary>
        /// GetById: Buscar solo un precio de cripto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PrecioCripto GetById(int id)
        {
            var datos = precioCriptoRepository.GetByID(id);
            return datos;
        }

        /// <summary>
        /// AddPrecioCripto: Agregar un precio de cripto
        /// </summary>
        /// <param name="precioCriptoModel"></param>
        /// <returns></returns>
        public string AddPrecioCripto(PrecioCriptoModel precioCriptoModel)
        {
            try
            {
                PrecioCripto precioCripto = new PrecioCripto();
                precioCripto.PrcId = precioCriptoModel.PrcId;
                precioCripto.CrmId = precioCriptoModel.CrmId;
                precioCripto.MonId = precioCriptoModel.MonId;
                precioCripto.PrcPrecio = precioCriptoModel.PrcPrecio;
                precioCripto.PrcPrecioFecha = precioCriptoModel.PrcPrecioFecha;

                precioCriptoRepository.Add(precioCripto);
                precioCriptoRepository.Save();
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException?.Message;
                return $"Error: {error} - {msg}";
            }
        }

        /// <summary>
        /// UpdatePrecioCripto: Actualiza el precio de cripto
        /// </summary>
        /// <param name="precioCriptoModel"></param>
        /// <returns></returns>
        public string UpdatePrecioCripto(PrecioCriptoModel precioCriptoModel)
        {
            try
            {
                PrecioCripto precioCripto = new PrecioCripto();
                precioCripto.PrcId = precioCriptoModel.PrcId;
                precioCripto.CrmId = precioCriptoModel.CrmId;
                precioCripto.MonId = precioCriptoModel.MonId;
                precioCripto.PrcPrecio = precioCriptoModel.PrcPrecio;
                precioCripto.PrcPrecioFecha = precioCriptoModel.PrcPrecioFecha;

                precioCriptoRepository.Update(precioCripto);
                precioCriptoRepository.Save();
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException?.Message;
                return $"Error: {error} - {msg}";
            }
        }

        /// <summary>
        /// DeletePrecioCripto: Eliminar un precio de cripto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletePrecioCripto(int id)
        {
            try
            {
                precioCriptoRepository.Delete(id);
                precioCriptoRepository.Save();
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException?.Message;
                return $"Error: {error} - {msg}";
            }
        }

        /// <summary>
        /// GetPrecioCripto: Buscar precio por CrmId, MonId y fecha/hora exacta
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <param name="fechaHora"></param>
        /// <returns></returns>
        public PrecioCripto GetPrecioCripto(int crmId, int monId, DateTime fechaHora)
        {
            PrecioCripto datos = precioCriptoRepository.GetByCriptoAndMonedaAndFecha(crmId, monId, fechaHora);
            return datos;
        }

        /// <summary>
        /// GetPrecioCriptoMoneda: Listar registros de precios por criptos y moneda
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        public IEnumerable GetPrecioCriptoMoneda(int crmId, int monId)
        {
            var datos = precioCriptoRepository.GetByCriptoAndMoneda(crmId, monId);
            return datos;
        }

        /// <summary>
        /// GetPrecioCriptoMonedaDetalle: Listar registros de precios por criptos y moneda en detalle
        /// </summary>
        /// <param name="crmId"></param>
        /// <param name="monId"></param>
        /// <returns></returns>
        public IEnumerable GetPrecioCriptoMonedaDetalle(int crmId, int monId)
        {
            var datos = precioCriptoRepository.GetByCriptoAndMonedaDetalle(crmId, monId);
            return datos;
        }

    }
}
