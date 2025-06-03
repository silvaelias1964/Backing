using Backing.Models;
using Backing.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Backing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        
        public readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService) 
        { 
            this.usuarioService = usuarioService;
        }


        // GET: /api/<UsuarioController>/lista
        [HttpGet("lista")]
        public IEnumerable GetListaUsuarios()
        {
            var datos = usuarioService.GetAll();
            return datos;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<UsuarioModel>  GetUsuario(int id)
        {
            var datos = usuarioService.GetById(id);
            if (datos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { statusCode = "200", result = datos });
            }
        }


        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post(UsuarioModel usuarioModel)
        {
            TryValidateModel(usuarioModel);
            try
            {
                usuarioService.AddUsuario(usuarioModel);
                return Ok(new { statusCode = "200", result = usuarioModel });
            }
            catch (Exception)
            {
                return BadRequest(new { Success = false, Message = "Ya existe el usuario o no pudo crearse" });
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.UsrId)
            {
                return BadRequest();
                //return NotFound();
            }

            try
            {
                //var datos = usuarioService.GetById(id);
                //if (datos == null)
                //{
                //    return NotFound();
                //}
                //else
                //{
                    usuarioService.UpdateUsuario(usuarioModel);
                    return Ok(new { statusCode = "200", Message = "Ya fué actualizado el usuario " });
                //}
            }
            catch (Exception)
            {

                return BadRequest(new { Success = false, Message = "No pudo actualizarse el usuario" });
            }

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = usuarioService.GetById(id);

                usuarioService.DeleteUsuario(id);
                return Ok(new { Success = true, Message = "El usuario " + data.UsrNombre + ", fué eliminado", data = data.UsrId });
            }
            catch
            {
                return BadRequest(new { Success = false, Message = "No pudo eliminarse el usuario" });
            }
        }
    }
}
