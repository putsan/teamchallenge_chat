namespace Ldis_Project_Reliz.Server.Services.Interfaces
{
    public interface ILoadImageOnServerService
    {
        string LoadUserAvatar(IFormFile file,string UserName);
        string LoadChatAvatar(IFormFile file, string ChatName);
    }
}
