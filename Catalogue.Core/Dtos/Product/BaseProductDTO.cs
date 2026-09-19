namespace Catalogue.Core.Dtos.Product
{
    public class BaseProductDTO
    {
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
    }
}
