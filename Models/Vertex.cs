namespace CampusNet.Models
{
    public class Vertex
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Vertex(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
