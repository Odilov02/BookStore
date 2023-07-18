using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    public string Save(IFormFile file, string folderName)
    {
        string fileName = $"{folderName}\\{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";
        string path = Path.Combine($"wwwroot\\img", fileName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }
        return fileName;
    }
}