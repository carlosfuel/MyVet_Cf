using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyVet_Cf.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
    }
}