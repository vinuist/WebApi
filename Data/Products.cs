using System;
using System.Text.Json.Serialization;

namespace WebApi.Data
{
    public class Products
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public string   ImagePath { get; set; }

        public int? CategoryId { get; set; }
       // [JsonIgnore]
        public Category Category { get; set; }
    }
}
