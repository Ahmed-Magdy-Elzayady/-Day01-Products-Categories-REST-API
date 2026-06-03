using System.Text.Json.Serialization;

namespace Day01.ViewModels
{
    public class ProductAddVM
    {
      
        public int  CategId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
       
    }
}
