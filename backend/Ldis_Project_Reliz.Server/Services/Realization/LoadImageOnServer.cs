using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using System.Drawing;
using System.Text;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class LoadImageOnServer : ILoadImageOnServerService
    {
        IRepository Repository;
        public LoadImageOnServer(IRepository Repository)
        {
            this.Repository = Repository;
        }
        public string LoadChatAvatar(IFormFile file, string ChatName)
        {
            int CountSymbolsChatName = ChatName.Length;
            StringBuilder builder = new StringBuilder(ChatName);
            builder.Insert(CountSymbolsChatName,"ChatAvatar");
            string ImageName = Convert.ToString(builder);
            string FullPathToFile = $"D:\\DotNetProject\\Ldis_Project_Reliz\\Ldis_Project_Reliz.Server\\Images\\{builder}";
            using (Bitmap bitmap = new Bitmap(file.OpenReadStream()))
            {
                bitmap.Save(FullPathToFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ImageName;
        }

        public string LoadUserAvatar(IFormFile file,string UserName)
        {
            int CountSymbolsChatName = UserName.Length;
            StringBuilder builder = new StringBuilder(UserName);
            builder.Insert(CountSymbolsChatName, "UserAvatar");
            string ImageName = Convert.ToString(builder);
            string FullPathToFile = $"D:\\DotNetProject\\Ldis_Project_Reliz\\Ldis_Project_Reliz.Server\\Images\\{ImageName}";
            using (Bitmap bitmap = new Bitmap(file.OpenReadStream()))
            {                
                bitmap.Save(FullPathToFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ImageName;
        }
    }
}