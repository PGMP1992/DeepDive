namespace ServerManagement.Models
{
    public interface IServerRepos
    {
        void Add(Server server);
        List<Server> GetAll();
        List<Server> GetByCity(string cityName);
        Server? GetById(int id);
        void Update(int serverId, Server server);
        void Delete(int serverId);
        List<Server> Search(string serverFilter);
    }
}
