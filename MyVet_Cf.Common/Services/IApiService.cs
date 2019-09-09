using System.Threading.Tasks;
using MyVet_Cf.Common.Models;


namespace MyVet_Cf.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetOwnerByEmail(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);
    }
}

