namespace Backend.Models.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class ToyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }

    public class CategoryWithToysDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ToyDto> Toys { get; set; } = new List<ToyDto>();
    }
}