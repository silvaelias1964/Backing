using Backing.Models;
using Backing.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Backing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioCriptoController : ControllerBase
    {
        public readonly IPrecioCriptoService precioCriptoService;

        public PrecioCriptoController(IPrecioCriptoService precioCriptoService)
        {
            this.precioCriptoService = precioCriptoService;
        }

        // GET: /api/<PrecioCriptoController>/lista
        [HttpGet("lista")]
        public IEnumerable GetListaPreciosCripto()
        {
            var datos = precioCriptoService.GetAll();
            return datos;
        }

        // GET: /api/<PrecioCriptoController>/lista
        [HttpGet("listaCriptoMoneda")]
        public IEnumerable GetListaPreciosCriptoMoneda([Required(ErrorMessage = "El codigo de Criptomoneda es obligatorio")] int crmId, [Required(ErrorMessage = "El codigo de Moneda es obligatorio")] int monId)
        {
            var datos = precioCriptoService.GetPrecioCriptoMoneda(crmId, monId);
            return datos;
        }

        // GET: /api/<PrecioCriptoController>/listaDetalle
        [HttpGet("listaCriptoMonedaDetalle")]
        public IEnumerable GetListaPreciosCriptoMonedaDetalle([Required(ErrorMessage = "El codigo de Criptomoneda es obligatorio")] int crmId, [Required(ErrorMessage = "El codigo de Moneda es obligatorio")] int monId)
        {
            var datos = precioCriptoService.GetPrecioCriptoMonedaDetalle(crmId, monId);
            return datos;
        }

        // GET api/<PrecioCriptoController>/5
        [HttpGet("{id}")]
        public ActionResult<PrecioCriptoModel> GetPrecioCripto(int id)
        {
            var datos = precioCriptoService.GetById(id);
            if (datos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { statusCode = "200", result = datos });
            }
        }

        // POST api/<PrecioCriptoController>
        [HttpPost]
        public ActionResult Post(PrecioCriptoModel precioCriptoModel)
        {
            TryValidateModel(precioCriptoModel);
            try
            {
                var datos = precioCriptoService.GetPrecioCripto(precioCriptoModel.PrcId, precioCriptoModel.MonId, precioCriptoModel.PrcPrecioFecha);
                if (datos == null)
                {
                    precioCriptoService.AddPrecioCripto(precioCriptoModel);
                    return Ok(new { statusCode = "200", result = precioCriptoModel });
                }
                else
                {
                    return Ok(new { Success = false, Message = "Ya existe un precio para este cripto en la fecha y hora" });
                }

            }
            catch (Exception)
            {
                return BadRequest(new { Success = false, Message = "Ya existe el precio o no pudo crearse" });
            }
        }

        // PUT api/<PrecioCriptoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, PrecioCriptoModel precioCriptoModel)
        {
            if (id != precioCriptoModel.PrcId)
            {
                return BadRequest();
            }

            try
            {
                precioCriptoService.UpdatePrecioCripto(precioCriptoModel);
                return Ok(new { statusCode = "200", Message = "Ya fué actualizado el precio de cripto" });
            }
            catch (Exception)
            {
                return BadRequest(new { Success = false, Message = "No pudo actualizarse el precio de cripto" });
            }
        }

        // DELETE api/<PrecioCriptoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = precioCriptoService.GetById(id);

                precioCriptoService.DeletePrecioCripto(id);
                return Ok(new { Success = true, Message = "El precio con Id " + data.PrcId + " fué eliminado", data = data.PrcId });
            }
            catch
            {
                return BadRequest(new { Success = false, Message = "No pudo eliminarse el precio de cripto" });
            }
        }
    }
}
