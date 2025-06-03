using Backing.Data;
using Backing.Models;
using Microsoft.EntityFrameworkCore;

namespace Backing.Repository.IRepository
{
    public interface IUsuarioRepository : IDisposable
    {
        /// <summary>
        /// GetListAll: Toda la lista de usuarios
        /// </summary>
        /// <returns></returns>                
        List<Usuario> GetListAll();

        /// <summary>
        /// GetById: Traer solo un usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario GetByID(int id);

        /// <summary>
        /// Add: Agregar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        void Add(Usuario usuario);

        /// <summary>
        /// Update: Actualiza un usuario
        /// </summary>
        /// <param name="usuario"></param>
        void Update(Usuario usuario);

        /// <summary>
        /// Delete: Eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// GetUser: Busca un usuario por correo y clave
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario GetUser(string correo, string clave);

        /// <summary>
        /// Guardar los cambios realizados
        /// </summary>
        void Save();

    }
}
