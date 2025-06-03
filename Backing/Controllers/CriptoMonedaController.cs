using Backing.Models;
using Backing.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Backing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CriptoMonedaController : ControllerBase
    {
        public readonly ICriptoMonedaService criptoMonedaService;

        public CriptoMonedaController(ICriptoMonedaService criptoMonedaService)
        {
            this.criptoMonedaService = criptoMonedaService;
        }

        // GET: /api/<CriptoMonedaController>/lista
        [HttpGet("lista")]
        public IEnumerable GetListaCriptoMonedas()
        {
            var datos = criptoMonedaService.GetAll();
            return datos;
        }

        // GET api/<CriptoMonedaController>/5
        [HttpGet("{id}")]
        public ActionResult<CriptoMonedaModel> GetCriptoMoneda(int id)
        {
            var datos = criptoMonedaService.GetById(id);
            if (datos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { statusCode = "200", result = datos });
            }
        }

        // POST api/<CriptoMonedaController>
        [HttpPost]
        public ActionResult Post(CriptoMonedaModel criptoMonedaModel)
        {
            TryValidateModel(criptoMonedaModel);
            try
            {
                criptoMonedaService.AddCriptoMoneda(criptoMonedaModel);
                return Ok(new { statusCode = "200", result = criptoMonedaModel });
            }
            catch (Exception)
            {
                return BadRequest(new { Success = false, Message = "Ya existe la criptomoneda o no pudo crearse" });
            }
        }

        // PUT api/<CriptoMonedaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, CriptoMonedaModel criptoMonedaModel)
        {
            if (id != criptoMonedaModel.CrmId)
            {
                return BadRequest();
            }

            try
            {
                criptoMonedaService.UpdateCriptoMoneda(criptoMonedaModel);
                return Ok(new { statusCode = "200", Message = "Ya fué actualizada la criptomoneda" });
            }
            catch (Exception)
            {
                return BadRequest(new { Success = false, Message = "No pudo actualizarse la criptomoneda" });
            }
        }

        // DELETE api/<CriptoMonedaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = criptoMonedaService.GetById(id);

                criptoMonedaService.DeleteCriptoMoneda(id);
                return Ok(new { Success = true, Message = "La criptomoneda " + data.CrmNombre + ", fué eliminada", data = data.CrmId });
            }
            catch
            {
                return BadRequest(new { Success = false, Message = "No pudo eliminarse la criptomoneda" });
            }
        }
    }
}
