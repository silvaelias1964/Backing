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
    public class MonedaController : ControllerBase
    {
        public readonly IMonedaService monedaService;

        public MonedaController(IMonedaService monedaService)
        {
            this.monedaService = monedaService;
        }

        // GET: /api/<MonedaController>/lista
        [HttpGet("lista")]
        public IEnumerable GetListaMonedas()
        {
            var datos = monedaService.GetAll();
            return datos;
        }

        // GET api/<MonedaController>/5
        [HttpGet("{id}")]
        public ActionResult<MonedaModel> GetMoneda(int id)
        {
            var datos = monedaService.GetById(id);
            if (datos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { statusCode = "200", result = datos });
            }
        }

        // POST api/<MonedaController>
        [HttpPost]
        public ActionResult Post(MonedaModel monedaModel)
        {
            TryValidateModel(monedaModel);
            try
            {
                monedaService.AddMoneda(monedaModel);
                return Ok(new { statusCode = "200", result = monedaModel });
            }
            catch (Exception)
            {
                return BadRequest(new { Success = false, Message = "Ya existe la moneda o no pudo crearse" });
            }
        }

        // PUT api/<MonedaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, MonedaModel monedaModel)
        {
            if (id != monedaModel.MonId)
            {
                return BadRequest();
            }

            try
            {
                monedaService.UpdateMoneda(monedaModel);
                return Ok(new { statusCode = "200", Message = "Ya fué actualizada la moneda" });
            }
            catch (Exception)
            {
                return BadRequest(new { Success = false, Message = "No pudo actualizarse la moneda" });
            }
        }

        // DELETE api/<MonedaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = monedaService.GetById(id);

                monedaService.DeleteMoneda(id);
                return Ok(new { Success = true, Message = "La moneda " + data.MonNombre + ", fué eliminada", data = data.MonId });
            }
            catch
            {
                return BadRequest(new { Success = false, Message = "No pudo eliminarse la moneda" });
            }
        }
    }
}
