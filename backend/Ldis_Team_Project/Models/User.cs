namespace Ldis_Team_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Actual { get; set; }
        public string Status { get; set; }
        public string ImageAvatarLink { get; set; }
        public ICollection<Message> MessageId { get; set; }
        public List<Chat> Chats { get; set; } = new List<Chat>();
        public ICollection<NoRegisterUser> PersonalMessageNoRegisterUserId { get; set; }
    }
}