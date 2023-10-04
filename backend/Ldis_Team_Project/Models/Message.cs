namespace Ldis_Team_Project.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateSend { get; set; }
        public ICollection<Chat> ChatId { get; set; }
        public ICollection<User> UserId { get; set; }
        public int Actual { get; set; }
    }
}