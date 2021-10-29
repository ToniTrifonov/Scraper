using Newtonsoft.Json;

namespace Scraper
{
    public class Product
    {
        public Product(string name, string price, decimal rating)
        {
            this.Name = name;
            this.Price = price;
            this.Rating = rating;
        }

        [JsonProperty(PropertyName = "productName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public decimal Rating { get; set; }
    }
}
