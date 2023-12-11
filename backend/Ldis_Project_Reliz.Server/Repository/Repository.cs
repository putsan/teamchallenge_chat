using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.LdisDbContext;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Ldis_Team_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ldis_Project_Reliz.Server.Repository
{
    public class RepositoryRealization : IRepository
    {
        DbContextApplication Context;
        ILoadImageOnServerService LoadImage;
        public RepositoryRealization(DbContextApplication Context, ILoadImageOnServerService LoadImage)
        {
            this.Context = Context;
            this.LoadImage = LoadImage;
        }
        public async Task AddMessage(string Message, string GroupName, string UserName,string Email)
        {
            var Chat = await Context.Chats.Include(x => x.Visible).Include(x => x.Messages).FirstOrDefaultAsync(x => x.NameChat == GroupName);
            var User = await Context.Users.Include(x => x.Messages).FirstOrDefaultAsync(x => x.Enail == Email);
            string TypeMessage = null;
            if (Chat.Visible.TypeVisible == "public")
            {
                TypeMessage = "public";
            }
            else if (Chat.Visible.TypeVisible == "private")
            {
                TypeMessage = "private";
            }
            var MessageTypeInstance = new MessageType()
            {
                Messages = new List<Message>(),
                TypeMessage = TypeMessage,
            };
            var MessageInstance = new Message
            {
                Chats = new List<Chat> (),
                Users = new List<User> (),
                Content = Message,
                Timestamp = DateTime.Now,
                IsRead = true,
                edited = false,
                Reactions = new List<Reaction>(),
                ForwardedFrom = User,
                ForwardedFromId = User.Id,
                deletedByReceiver = false,
                deletedBySender = false,
                MessageType = MessageTypeInstance
            };
            Chat.Messages.Add(MessageInstance);
            User.Messages.Add(MessageInstance);
            Context.AddRange(MessageInstance,MessageTypeInstance);
            Context.SaveChanges();
        }
        public void AddToGroup(string UserName, string GroupName, string Email)
        {
            var Chat = Context.Chats.Include(x => x.Users).FirstOrDefault(x => x.NameChat == GroupName);
            var User = Context.Users.Include(x => x.Chats).FirstOrDefault(x => x.UserName == UserName && Email == Email);
            Chat.Users.Add(User);
            User.Chats.Add(Chat);
            Context.SaveChanges();
        }
        public void CreateNewUser(string Email, string UserName, string Password, string ImageLink)
         {
            if (ImageLink == null)
            {
                ImageLink = "https://icons.veryicon.com/png/o/miscellaneous/rookie-official-icon-gallery/225-default-avatar.png";
            }
            Random rand = new Random();
             string CodeImg = Convert.ToString(rand.Next(100000));
             var ImageInstance = new Image()
             {
                Link = ImageLink,
                CodeImg = CodeImg,
                Chats = new List<Chat>(),
                Users = new List<User>()
             };
            var UserInstance = new User()
            {
                UserName = UserName,
                Password = Password,
                Avatar = ImageInstance,
                IsRegidtred = true,
                Actual = 1,
                Status = "Online",
                Enail = Email,
                ForwardedMessages = new List<Message>(),
                Messages = new List<Message>(),
                RegisteredAt = DateTime.Now
            };
            Context.AddRange(UserInstance,ImageInstance);
            Context.SaveChanges();
        }
        public void ExitFromGroup(string Email, string ChatName)
        {
            var User = Context.Users.FirstOrDefault(x => x.Enail == Email);
            var Chat = Context.Chats.FirstOrDefault(x => x.NameChat == ChatName);
            User.Chats.Remove(Chat);
            Chat.Users.Remove(User);
            Context.SaveChanges();
        }
        public bool FindUserForСheckExistence(string Email)
        {
            var User = Context.Users.AsNoTracking().FirstOrDefault(x => x.Enail == Email);
            if (User == null)
                return false;
            else
              return true;
        }
        public User FindUserByEmailForDeletedTimer (string Email)
        {
            var User = Context.Users.Include(x => x.Chats).Include(x => x.Messages).FirstOrDefault(x => x.Enail == Email);
            return User;
        }
        public bool FindUserForСheckExistenceLogin(string Email, string Password)
        {
            var User = Context.Users.AsNoTracking().FirstOrDefault(x => x.Enail == Email && x.Password == Password);
            if (User == null)
                return false;
            else
                return true;
        }
        public bool FindUserForСheckExistenceRegistration(string Email, string Password)
        {
            var User = Context.Users.AsNoTracking().FirstOrDefault(x => x.Enail == Email || x.Password == Password);
            if (User == null)
                return false;
            else
                return true;
        }
        public void SetStatusConnected(string Email)
        {
            var User = Context.Users.FirstOrDefault(x => x.Enail == Email);
            User.Status = "Connected";
            Context.SaveChanges();
        }
        public void SetStatusDisconnected(string Email)
        {
            var User = Context.Users.FirstOrDefault(x => x.Enail == Email);
            User.Status = "Disconnected";
            Context.SaveChanges();
        }
        public void CreateNewGroup(string NameGroup,string Description,int CountUsers,bool AutoDeletingUser,string Genre,string Visible, IFormFile file )
        {
            string ImageName = LoadImage.LoadChatAvatar(file,NameGroup);
            var AvatarInstance = AddNewImage(ImageName);
            var GenreInstance = new Genre
            {
                NameGenre = Genre,
                Chats = new List<Chat>()
            };
            var VisibleInstance = new Visible
            {
                TypeVisible = Visible,
                Chats = new List<Chat>()               
            };
            Random rand = new Random();
            string CodeImg = Convert.ToString(rand.Next(100000));

            var GroupInstance = new Chat
            {
                NameChat = NameGroup,
                Description = Description,
                CountUsers = CountUsers,
                AutoDeletingUser = AutoDeletingUser,
                Genre = GenreInstance,
                CreatDate = DateTime.Now,
                Messages = new List<Message>(),
                Users = new List<User>(),
                Visible = VisibleInstance,
                Avatar = AvatarInstance,
                AvatarId = AvatarInstance.Id,
                Tags = new List<Tag>()
            };
            Context.AddRange(GenreInstance,GroupInstance);
            Context.SaveChanges();
        }
        public List<Chat> FindChat(string NameChat)
        {
            var SuitableChatName = new List<string>();
            var SuitableChat = new List<Chat>();
            var TempCollectionChat = Context.Chats.AsNoTracking().ToList();
            foreach (var item in TempCollectionChat)
            {
                int distance = LevenshtainDistance.Calculate(NameChat.ToLower(),item.NameChat.ToLower());
                if (distance <= 2)
                {
                    SuitableChatName.Add(item.NameChat);
                }
                foreach (string name in SuitableChatName)
                {
                    var Chat = TempCollectionChat.FirstOrDefault(x => x.NameChat == name);
                    SuitableChat.Add(Chat);
                }
            }
            return SuitableChat;
        }
        public Image AddNewImage(string ImageCode)
        {
            var ImageInstance = new Image
            {
                CodeImg = ImageCode,
                Chats = new List<Chat>(),
                Users = new List<User>(),
            };
            return ImageInstance;
        }
    }
}