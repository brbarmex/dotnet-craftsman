using System.Threading.Tasks;

namespace Craftsman.Domain.Interfaces.IGateway
{
    public interface IZipCodeServices
    {
        Task<bool> ExistsInBrazil(string value);
    }
}