
namespace PriceRadar.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Brand { get; private set; }
    public string? Model { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    public Product(string name, string brand, Category category, string? model = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do produto é obrigatório.", nameof(name));

        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("A marca do produto é obrigatória.", nameof(brand));

        Id = Guid.NewGuid();
        Name = name.Trim();
        Brand = brand.Trim();
        Model = string.IsNullOrWhiteSpace(model) ? null : model.Trim();

        Category = category ?? throw new ArgumentNullException(nameof(category));
        CategoryId = Category.Id;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do produto é obrigatório.", nameof(name));

        Name = name.Trim();
    }

    public void UpdateBrand(string brand)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("A marca do produto é obrigatória.", nameof(brand));

        Brand = brand.Trim();
    }

    public void UpdateModel(string? model)
    {
        Model = string.IsNullOrWhiteSpace(model) ? null : model.Trim();
    }
}
