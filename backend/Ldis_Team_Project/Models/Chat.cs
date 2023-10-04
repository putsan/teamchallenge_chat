using System.Collections.ObjectModel;

namespace Ldis_Team_Project.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ChatName { get; set; }
        public ICollection<User> UserId { get; set; }   
        public ICollection<Message> MessageId { get; set; }
        public int Actual { get; set; }               
    }
}
