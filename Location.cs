namespace Modas.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public string toString()
        {
            string output = "{\n";
            output += $"Location ID: {LocationId}\n";
            output += $"Name: {Name}\n";
            output += "}";
            return output;
        }
    }
}