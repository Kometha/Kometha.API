using Kometha.API.Dataa;
using Kometha.API.Models.Domain;

namespace Kometha.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly KomethaDBContext dBContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, KomethaDBContext dBContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dBContext = dBContext;
        }
        public async Task<Image> Upload(Image image)
        {
            // Asegurar que exista la carpeta "Images"
            var imagesDirectory = Path.Combine(webHostEnvironment.ContentRootPath, "Images");

            if (!Directory.Exists(imagesDirectory))
            {
                //Si el directorio no existe, entonces crearlo
                Directory.CreateDirectory(imagesDirectory);
            }

            // Generar ruta completa del archivo
            var fileNameWithExtension = $"{image.FileName}{image.FileExtension}";
            var localFilePath = Path.Combine(imagesDirectory, fileNameWithExtension);

            // Subir imagen al servidor local
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // Crear URL pública de la imagen
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://" +
                              $"{httpContextAccessor.HttpContext.Request.Host}" +
                              $"{httpContextAccessor.HttpContext.Request.PathBase}/Images/{fileNameWithExtension}";

            image.FilePath = urlFilePath;

            // Guardar detalles en la BD
            await dBContext.Images.AddAsync(image);
            await dBContext.SaveChangesAsync();

            return image;
        }

    }
}
