using Backing.Data;
using Backing.Models;
using Backing.Repository.IRepository;
using Backing.Services.IServices;
using System.Collections;

namespace Backing.Services
{

    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) 
        { 
            this.usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// GetAll: Traer toda la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAll() 
        {
            var datos = usuarioRepository.GetListAll();
            return datos;        
        }

        /// <summary>
        /// GetById: Buscar solo un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario GetById(int id) 
        {
            var datos = usuarioRepository.GetByID(id);
            return datos;
        }

        /// <summary>
        /// AddUsuario: Agregar un usuario
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        public string AddUsuario(UsuarioModel usuarioModel) 
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.UsrId = usuarioModel.UsrId;
                usuario.UsrNombre = usuarioModel.UsrNombre;
                usuario.UsrCorreo = usuarioModel.UsrCorreo;
                usuario.UsrUsuario = usuarioModel.UsrUsuario;
                usuario.UsrClave = usuarioModel.UsrClave;
                usuario.UsrRol = usuarioModel.UsrRol;

                usuarioRepository.Add(usuario);
                usuarioRepository.Save();
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
        /// UpdateUsuario: Actualiza el usuario
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        public string UpdateUsuario(UsuarioModel usuarioModel) 
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.UsrId = usuarioModel.UsrId;
                usuario.UsrNombre = usuarioModel.UsrNombre;
                usuario.UsrCorreo = usuarioModel.UsrCorreo;
                usuario.UsrUsuario = usuarioModel.UsrUsuario;
                usuario.UsrClave = usuarioModel.UsrClave;
                usuario.UsrRol = usuarioModel.UsrRol;

                usuarioRepository.Update(usuario);
                usuarioRepository.Save();
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
        /// DeleteUsuario: Eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteUsuario(int id) 
        {
            try
            {
                usuarioRepository.Delete(id);
                usuarioRepository.Save();
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
        /// GetUsuario: Buscar datos del usuario por usuario y clave
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public Usuario GetUsuario(string usuario, string clave) 
        {
            Usuario datos = new Usuario();
            datos= usuarioRepository.GetUser(usuario, clave);
            return datos;
        }

    }
}
