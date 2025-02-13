
namespace WAS.Client.Models
{
    public interface IServersRepos
    {
        Task<List<Server>> GetAllAsync();
        Task AddAsync(Server server);
        Task UpdateAsync(Server server);
        Task DeleteAsync(int id);
        Task<int> GetNextIdAsync();
        Task<Server?> GetByIdAsync(int id);
    }
}