using Newtonsoft.Json;

namespace EFCore.Example.Application.DTOs
{
    [JsonProperty("Product")]
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
