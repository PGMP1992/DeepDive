using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;

namespace ServerManagement.Models
{
    public class ServerRepos : IServerRepos
    {
        private readonly IDbContextFactory<AppDbContext> contextFactory;

        public ServerRepos(IDbContextFactory<AppDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Add(Server server)
        {
            using var db = this.contextFactory.CreateDbContext();
            db.Servers.Add(server);
            db.SaveChanges();
        }

        public List<Server> GetAll()
        {
            using var db = this.contextFactory.CreateDbContext();
            return db.Servers.ToList();
        }

        public List<Server> GetByCity(string cityName)
        {
            using var db = this.contextFactory.CreateDbContext();
            return db.Servers.Where(x => x.City != null 
                && x.City.ToLower().IndexOf( cityName.ToLower() ) >= 0).ToList();
        }

        public Server? GetById(int id)
        {
            using var db = this.contextFactory.CreateDbContext();
            var server = db.Servers.Find(id);
            if (server is not null) 
                return server;

            return new Server();
        }

        public void Update(int serverId, Server server)
        {
            if (server == null) 
                throw new ArgumentNullException(nameof(server));
            
            if (serverId != server.Id) 
                return;

            using var db = this.contextFactory.CreateDbContext();
            var serverToUpdate = db.Servers.Find(serverId);
            
            if (serverToUpdate is not null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;

                db.SaveChanges();
            }
        }

        public void Delete(int serverId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var server = db.Servers.Find(serverId);
            if (server is null) return;

            db.Servers.Remove(server);
            db.SaveChanges();
        }

        public List<Server> Search(string serverFilter)
        {
            using var db = this.contextFactory.CreateDbContext();
            return db.Servers.Where(x => x.Name != null 
                && x.Name.ToLower().IndexOf(serverFilter.ToLower()) >= 0).ToList();
        }
    }
}
