using WebBacking.Models;

namespace WebBacking.Service.IService
{
    public interface ICriptosService
    {
        Task<List<CriptoPrecioModel>> Lista(string token);
    }
}