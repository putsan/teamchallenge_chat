using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class LoadUploadImageServer : ILoadUploadImageServerService
    {

        public Dictionary<string, string> LoadChatAvatar(IFormFile file, string ChatName)
        {
            int CountSymbolsChatName = ChatName.Length;
            StringBuilder builder = new StringBuilder(ChatName);
            builder.Insert(CountSymbolsChatName, "ChatAvatar.jpg");
            string ImageName = Convert.ToString(builder);
            string FullPathToFile = $"D:\\DotNetProject\\teamchallenge_chat\\backend\\Ldis_Project_Reliz.Server\\Images\\{ImageName}";
            using (Bitmap bitmap = new Bitmap(file.OpenReadStream()))
            {
                bitmap.Save(FullPathToFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            var AvatarInfo = new Dictionary<string, string>()
            {
                {"ImageName",ImageName },
                {"FullPathToFile",FullPathToFile }
            };
            return AvatarInfo;
        }

        public Dictionary<string, string> LoadUserAvatar(IFormFile file,string UserName)
        {
            int CountSymbolsChatName = UserName.Length;
            StringBuilder builder = new StringBuilder(UserName);
            builder.Insert(CountSymbolsChatName, "UserAvatar.jpg");
            string ImageName = Convert.ToString(builder);
            string FullPathToFile = $"D:\\DotNetProject\\teamchallenge_chat\\backend\\Ldis_Project_Reliz.Server\\Images\\{ImageName}";
            using (Bitmap bitmap = new Bitmap(file.OpenReadStream()))
            {
                bitmap.Save(FullPathToFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            var AvatarInfo = new Dictionary<string, string>()
            {
                {"ImageName",ImageName },
                {"FullPathToFile",FullPathToFile }
            };
            return AvatarInfo;
        }

        public FileStreamResult UploadImage(string ImageLink)
        {
            FileStream fileStream = new FileStream(ImageLink, FileMode.Open, FileAccess.Read);
            FileStreamResult fileResult = new FileStreamResult(fileStream, "application/octet-stream");
            fileResult.FileDownloadName = "Image.jpg";
            return fileResult;
        }
    }
}