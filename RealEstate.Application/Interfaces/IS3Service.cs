using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IS3Service
    {
        Task<string> UploadBase64ImageAsync(string base64String, string folderName = "projects");
    }
}
