using WebBacking.Models;

namespace WebBacking.Service.IService
{
    public interface IAutenticarApiService
    {
        Task<Usuario> GetLogin(string correo, string clave);
    }
}