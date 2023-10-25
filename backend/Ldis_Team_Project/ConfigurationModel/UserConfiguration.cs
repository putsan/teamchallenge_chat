using Ldis_Team_Project.Models;
using LdisProduction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ldis_Team_Project.ConfigurationModel
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Chats).WithMany(x => x.Users);
            builder.HasMany(x => x.MessageId).WithMany(x => x.UserId);
            builder.HasMany(x => x.PersonalMessageNoRegisterUserId).WithMany(x => x.PersonalMessageId);
        }
    }
}
