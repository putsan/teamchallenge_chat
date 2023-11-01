using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace Ldis_Team_Project.SignalR
{
    public class GroupChatHub : Hub
    {
        public const string EmailUserCookie = "EmailCookie";
        IHttpContextAccessor _ContextAccessor;
        IRepositoryService _Repository;
        IMemoryCache _Cache;
        ILoadImageService _LoadImage;
        public GroupChatHub(IHttpContextAccessor accessor, IRepositoryService repository, IMemoryCache cache,ILoadImageService image)
        {
            _LoadImage = image;
            _Cache = cache;
            _Repository = repository;
            _ContextAccessor = accessor;
        }
        public async Task Enter(string UserName, string GroupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
            await Clients.Group(GroupName).SendAsync("Notify", $"{UserName} додався до группи");
            string Email = (string)_Cache.Get(EmailUserCookie); /*"illanazarov966@gmail.com"*/;
            _Repository.AddUserToGroup(Email, GroupName);
        }

        public async Task ExitGroup(string UserName, string GroupName)
        {
            await Clients.Group(GroupName).SendAsync("Notify", $"{UserName} вийшов з группи");
            string Email = (string)_Cache.Get(EmailUserCookie) /* "illanazarov966@gmail.com"*/;
            _Repository.DeleteUserFromGroup(Email, GroupName);
        }

        public async Task SendMessage(string Message, string UserName, string GroupName)
        {
            await Clients.Group(GroupName).SendAsync("Receive", Message, UserName);
            _Repository.AddMessage(Message, GroupName, UserName);
        }

        public override Task OnConnectedAsync()
       {
            string Email = (string)_Cache.Get(EmailUserCookie);
            _Repository.ChangeStatus("illanazarov966@gmail.com", "Connected");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string Email = (string)_Cache.Get(EmailUserCookie);
            _Repository.ChangeStatus("illanazarov966@gmail.com", "Disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
