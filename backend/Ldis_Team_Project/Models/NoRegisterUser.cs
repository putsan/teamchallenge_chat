namespace Ldis_Team_Project.Models
{
    public class NoRegisterUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<User>? PersonalMessageId { get; set; }
    }
}
