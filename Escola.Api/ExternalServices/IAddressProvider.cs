using System.Threading.Tasks;

namespace Escola.Api.ExternalServices
{
    public interface IAddressProvider
    {
        Task<object> GetAdress(int cep);
    }
}
