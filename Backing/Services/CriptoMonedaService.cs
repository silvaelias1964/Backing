using Backing.Data;
using Backing.Models;
using Backing.Repository.IRepository;
using Backing.Services.IServices;
using System.Collections;

namespace Backing.Services
{
    public class CriptoMonedaService : ICriptoMonedaService
    {
        public readonly ICriptoMonedaRepository criptoMonedaRepository;

        public CriptoMonedaService(ICriptoMonedaRepository criptoMonedaRepository)
        {
            this.criptoMonedaRepository = criptoMonedaRepository;
        }

        /// <summary>
        /// GetAll: Traer toda la lista de criptomonedas
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAll()
        {
            var datos = criptoMonedaRepository.GetListAll();
            return datos;
        }

        /// <summary>
        /// GetById: Buscar solo una criptomoneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CriptoMoneda GetById(int id)
        {
            var datos = criptoMonedaRepository.GetByID(id);
            return datos;
        }

        /// <summary>
        /// AddCriptoMoneda: Agregar una criptomoneda
        /// </summary>
        /// <param name="criptoMonedaModel"></param>
        /// <returns></returns>
        public string AddCriptoMoneda(CriptoMonedaModel criptoMonedaModel)
        {
            try
            {
                CriptoMoneda criptoMoneda = new CriptoMoneda();
                criptoMoneda.CrmId = criptoMonedaModel.CrmId;
                criptoMoneda.CrmNombre = criptoMonedaModel.CrmNombre;
                criptoMoneda.CrmSimbolo = criptoMonedaModel.CrmSimbolo;
                criptoMoneda.CrmWebOrigen = criptoMonedaModel.CrmWebOrigen;
                criptoMoneda.CrmDescripcion = criptoMonedaModel.CrmDescripcion;
                criptoMoneda.CrmFechaLanzamiento = criptoMonedaModel.CrmFechaLanzamiento;
                criptoMoneda.Fecha_Creacion = criptoMonedaModel.Fecha_Creacion;
                criptoMoneda.Fecha_Actualizacion = criptoMonedaModel.Fecha_Actualizacion;

                criptoMonedaRepository.Add(criptoMoneda);
                criptoMonedaRepository.Save();
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
        /// UpdateCriptoMoneda: Actualiza la criptomoneda
        /// </summary>
        /// <param name="criptoMonedaModel"></param>
        /// <returns></returns>
        public string UpdateCriptoMoneda(CriptoMonedaModel criptoMonedaModel)
        {
            try
            {
                CriptoMoneda criptoMoneda = new CriptoMoneda();
                criptoMoneda.CrmId = criptoMonedaModel.CrmId;
                criptoMoneda.CrmNombre = criptoMonedaModel.CrmNombre;
                criptoMoneda.CrmSimbolo = criptoMonedaModel.CrmSimbolo;
                criptoMoneda.CrmWebOrigen = criptoMonedaModel.CrmWebOrigen;
                criptoMoneda.CrmDescripcion = criptoMonedaModel.CrmDescripcion;
                criptoMoneda.CrmFechaLanzamiento = criptoMonedaModel.CrmFechaLanzamiento;
                criptoMoneda.Fecha_Creacion = criptoMonedaModel.Fecha_Creacion;
                criptoMoneda.Fecha_Actualizacion = criptoMonedaModel.Fecha_Actualizacion;

                criptoMonedaRepository.Update(criptoMoneda);
                criptoMonedaRepository.Save();
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
        /// DeleteCriptoMoneda: Eliminar una criptomoneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteCriptoMoneda(int id)
        {
            try
            {
                criptoMonedaRepository.Delete(id);
                criptoMonedaRepository.Save();
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
        /// GetCriptoMoneda: Buscar datos de la criptomoneda por nombre y símbolo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="simbolo"></param>
        /// <returns></returns>
        public CriptoMoneda GetCriptoMoneda(string nombre, string simbolo)
        {
            CriptoMoneda datos = criptoMonedaRepository.GetByNameAndSymbol(nombre, simbolo);
            return datos;
        }
    }
}
