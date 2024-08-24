using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IDelitoService
    {
        Task<List<DelitosDTO>> Lista();


    }
}
