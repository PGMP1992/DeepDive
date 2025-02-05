namespace ServerManagement.Models
{
    public static class CitiesRepos
    {
        private static List<String> cities = new List<String> 
        {
            "Toronto", 
            "Montreal", 
            "Ottawa", 
            "Calgary", 
            "Halifax" 
        };

        public static List<String> GetCities() => cities;
    }
}
