using System.Text.Json.Serialization;

namespace Day01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        //[JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
