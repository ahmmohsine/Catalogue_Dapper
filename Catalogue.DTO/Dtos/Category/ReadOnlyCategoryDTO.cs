namespace Catalogue.Core.Dtos.Category
{
    public class ReadOnlyCategoryDTO : BaseCategoryDTO
    {
        public int Id { get; set; }

        public static implicit operator ReadOnlyCategoryDTO(int v)
        {
            throw new NotImplementedException();
        }
    }
}
