﻿namespace WAS.Client.Models
{
    public static class ServersRepository
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server {  Id = 1, Name = "Server1", City = "Toronto" },
            new Server {  Id = 2, Name = "Server2", City = "Toronto" },
            new Server {  Id = 4, Name = "Server4", City = "Toronto" },
            new Server {  Id = 5, Name = "Server5", City = "Montreal" },
            new Server {  Id = 6, Name = "Server6", City = "Montreal" },
            new Server {  Id = 7, Name = "Server7", City = "Montreal" },
            new Server {  Id = 8, Name = "Server8", City = "Ottawa" },
            new Server {  Id = 9, Name = "Server9", City = "Ottawa" },
            new Server {  Id = 10, Name = "Server10", City = "Calgary" },
            new Server {  Id = 11, Name = "Server11", City = "Calgary" },
            new Server {  Id = 12, Name = "Server12", City = "Halifax" },
            new Server {  Id = 13, Name = "Server13", City = "Halifax" },
            new Server {  Id = 14, Name = "Server14", City = "Halifax" },
            new Server {  Id = 15, Name = "Server15", City = "Halifax" },
        };

        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.Id);
            server.Id = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.Id == id);
            if (server != null)
            {
                return new Server
                {
                    Id = server.Id,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                };
            }

            return null;
        }

        public static void UpdateServer(int Id, Server server)
        {
            if (Id != server.Id) return;

            var serverToUpdate = servers.FirstOrDefault(s => s.Id == Id);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public static void DeleteServer(int Id)
        {
            var server = servers.FirstOrDefault(s => s.Id == Id);
            if (server != null)
            {
                servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
