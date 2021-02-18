using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Infrastructure.Settings;

namespace Craftsman.Infrastructure.Gateways.ViaCep.Services
{
    public sealed class ViaCepGateway : IZipCodeServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ViaCepGateway(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;

       public async Task<bool> ExistsInBrazil(string value)
       {
            var responseMessage = await _httpClientFactory
                          .CreateClient("viaCep")
                          .GetAsync($"ws/{value}/json/")
                          .ConfigureAwait(false);

            return responseMessage.StatusCode == HttpStatusCode.OK;
       }
    }
}