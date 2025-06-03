using Backing.Data;
using Backing.Models;
using Backing.Repository;
using System.Collections;

namespace Backing.Services.IServices
{
    public interface IUsuarioService
    {
        /// <summary>
        /// GetAll: Traer toda la lista de usuarios
        /// </summary>
        /// <returns></returns>
        IEnumerable GetAll();

        /// <summary>
        /// GetById: Buscar solo un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario GetById(int id);

        /// <summary>
        /// AddUsuario: Agregar un usuario
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        string AddUsuario(UsuarioModel usuarioModel);

        /// <summary>
        /// UpdateUsuario: Actualiza el usuario
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        string UpdateUsuario(UsuarioModel usuarioModel);

        /// <summary>
        /// DeleteUsuario: Eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string DeleteUsuario(int id);

        /// <summary>
        /// GetUsuario: Buscar datos del usuario por usuario y clave
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        Usuario GetUsuario(string usuario, string clave);

    }
}
