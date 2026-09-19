namespace Catalogue.Core.Dtos.Product
{
    public class BaseProductDTO
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
    }
}
