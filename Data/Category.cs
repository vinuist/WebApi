using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public List<Products> Products{ get; set; }
    }
}
