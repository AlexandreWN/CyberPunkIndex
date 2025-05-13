using Dtos;

namespace Model;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Category()
    {

    }

    public static Category Create(CategoryDto dto)
    {
        return new Category()
        {
            Id = dto.Id,
            Name = dto.Name,
        };
    }
}