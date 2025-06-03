using Backing.Data;
using Backing.Models;
using Backing.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backing.Repository
{
    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        public readonly DatabaseContext dbContext;

        public UsuarioRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// GetListAll: Toda la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetListAll()
        {
            try
            {
                return dbContext.Usuario.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetById: Traer solo un usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario GetByID(int id)
        {
            return dbContext.Set<Usuario>().Find(id);  
        }

        /// <summary>
        /// Add: Agregar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        public void Add(Usuario usuario)
        {
            try
            {
                dbContext.Usuario.Add(usuario);                
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update: Actualiza un usuario
        /// </summary>
        /// <param name="usuario"></param>
        public void Update(Usuario usuario)
        {
            try
            {
                dbContext.Entry(usuario).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete: Eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {        
                Usuario? usuario  = dbContext.Usuario.Find(id);

                if (usuario != null)
                {
                    dbContext.Usuario.Remove(usuario);                    
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetUser: Busca un usuario por correo y clave
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario GetUser(string correo, string clave)
        {
            return dbContext.Usuario
             .FirstOrDefault(c => c.UsrCorreo == correo && c.UsrClave == clave);

        }



        /// <summary>
        /// Guardar los cambios realizados
        /// </summary>
        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
