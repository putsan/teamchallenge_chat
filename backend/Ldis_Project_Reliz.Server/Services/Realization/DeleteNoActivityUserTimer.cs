using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.LdisDbContext;
using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class DeleteNoActivityUserTimer : IDeleteNoActivityUserTimerService , IHostedService
    {
        Timer TimerInstance;
        IMemoryCache MemoryCache;
        public DeleteNoActivityUserTimer(IMemoryCache MemoryCache)
        {
            this.MemoryCache = MemoryCache;       
        }
        public void Delete(object obj)
        {
            try
            {
                var dbContextOptions = new DbContextOptions<DbContextApplication>();
                using (DbContextApplication dbContextApplication = new DbContextApplication(dbContextOptions))
                {
                    Console.WriteLine("Start");
                    MemoryCache.Set(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail, "illanazarov966@gmail.com");
                    string Email = (string)MemoryCache.Get(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail);
                    var User = dbContextApplication.Users.Include(x => x.Chats).FirstOrDefault(x => x.Enail == Email);
                    foreach (var item in User.Chats)
                    {
                        var Chat = dbContextApplication.Chats.Include(x => x.Messages).Include(x => x.Users).FirstOrDefault(x => x.Id == item.Id);
                        if (Chat.AutoDeletingUser == true && Chat.Messages.Count != 0)
                        {
                            var LastMessage = Chat.Messages.Last();
                            var Difference = DateTime.Now - LastMessage.Timestamp;
                            if (Difference.Value.TotalHours > 24)
                            {
                                Chat.Users.Remove(User);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    dbContextApplication.SaveChanges();
                }
            }
            catch (Exception exeption)
            {
                Log.Error($"Error {exeption.Message} Date {DateTime.Now}");
            }          
        }
        public void Start()
        {
            int IntervalCall = 24 * 60 * 1000;
            TimerCallback timerCallback = new TimerCallback(Delete);
            TimerInstance = new Timer(timerCallback, null, 0, 5000);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
     
}
