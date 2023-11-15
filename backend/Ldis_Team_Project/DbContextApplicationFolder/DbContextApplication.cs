using Ldis_Team_Project.ConfigurationModel;
using Ldis_Team_Project.Models;
using LdisProduction.Models;
using Microsoft.EntityFrameworkCore;
namespace Ldis_Team_Project.DbContextApplicationFolder
{
    public class DbContextApplication : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Visible> Visibles { get; set; }
        public DbContextApplication(DbContextOptions<DbContextApplication> options) : base (options)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConfigurationJsonSecret = new ConfigurationBuilder().AddUserSecrets<DbContextApplication>().Build();
            var ConnectionString = ConfigurationJsonSecret.GetConnectionString("DataBaseConnect");
            optionsBuilder.UseSqlite(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguraation());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
        }
    }
}
