namespace Homework_20220528.Models
{
    public class Exercise
    {
        public int? id { get; set; }
        public string? Medal { get; set; }
        public string? Name { get; set; }
        public string? Sport { get; set; }
        public int? PrizeMoney { get; set; }
    }
    public class People
    {
        public int? id { get; set; }
        public string? Name { get; set; }
        public string? Sport { get; set; }
    }
    public class Medal
    {
        public int? id { get; set; }
        public string? MedalName { get; set; }
        public int PrizeMoney { get; set; }
    }
}
