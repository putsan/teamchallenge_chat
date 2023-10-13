using Ldis_Team_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ldis_Team_Project.ConfigurationModel
{
    public class NoRegisterUserConfiguration : IEntityTypeConfiguration<NoRegisterUser>
    {
        public void Configure(EntityTypeBuilder<NoRegisterUser> builder)
        {
            builder.HasMany(x => x.PersonalMessageId).WithMany(x => x.PersonalMessageNoRegisterUserId);
        }
    }
}
