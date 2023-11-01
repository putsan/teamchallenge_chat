using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Services.Interfaces;
using System.Drawing;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class LoadImageOnServer : ILoadImageService
    {
        IHttpContextAccessor _AccessorContext;
        DbContextApplication _Context;
        public LoadImageOnServer(IHttpContextAccessor contextAccessor,DbContextApplication context)
        {
            _Context = context;
            _AccessorContext = contextAccessor;
        }
        public void LoadImage(IFormFile file)
        {
            string guid = Convert.ToString(Guid.NewGuid());
            IFormFile image = file;
            string ImageName = $"image{guid}.jpg";
            string FullPath = $"D:\\DotNetProject\\LdisGitProject\\teamchallenge_chat\\backend\\Ldis_Team_Project\\ClientApp\\Images\\{ImageName}";
            using (Bitmap bitmap = new Bitmap(image.OpenReadStream()))
            {
                bitmap.Save(FullPath,System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}
