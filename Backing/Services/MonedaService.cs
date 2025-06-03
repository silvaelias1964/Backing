using Backing.Data;
using Backing.Models;
using Backing.Repository.IRepository;
using Backing.Services.IServices;
using System.Collections;

namespace Backing.Services
{
    public class MonedaService : IMonedaService
    {
        public readonly IMonedaRepository monedaRepository;

        public MonedaService(IMonedaRepository monedaRepository)
        {
            this.monedaRepository = monedaRepository;
        }

        /// <summary>
        /// GetAll: Traer toda la lista de monedas
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAll()
        {
            var datos = monedaRepository.GetListAll();
            return datos;
        }

        /// <summary>
        /// GetById: Buscar solo una moneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Moneda GetById(int id)
        {
            var datos = monedaRepository.GetByID(id);
            return datos;
        }

        /// <summary>
        /// AddMoneda: Agregar una moneda
        /// </summary>
        /// <param name="monedaModel"></param>
        /// <returns></returns>
        public string AddMoneda(MonedaModel monedaModel)
        {
            try
            {
                Moneda moneda = new Moneda();
                moneda.MonId = monedaModel.MonId;
                moneda.MonNombre = monedaModel.MonNombre;
                moneda.MonSimbolo = monedaModel.MonSimbolo;

                monedaRepository.Add(moneda);
                monedaRepository.Save();
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
        /// UpdateMoneda: Actualiza la moneda
        /// </summary>
        /// <param name="monedaModel"></param>
        /// <returns></returns>
        public string UpdateMoneda(MonedaModel monedaModel)
        {
            try
            {
                Moneda moneda = new Moneda();
                moneda.MonId = monedaModel.MonId;
                moneda.MonNombre = monedaModel.MonNombre;
                moneda.MonSimbolo = monedaModel.MonSimbolo;

                monedaRepository.Update(moneda);
                monedaRepository.Save();
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
        /// DeleteMoneda: Eliminar una moneda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteMoneda(int id)
        {
            try
            {
                monedaRepository.Delete(id);
                monedaRepository.Save();
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException?.Message;
                return $"Error: {error} - {msg}";
            }
        }
    }
}
