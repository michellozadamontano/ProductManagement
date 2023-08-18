using ProductManagement.Domain.Common;

namespace ProductManagement.Domain.Entities;

public class Product : AuditableBaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; set; }

    protected Product()
    {
    }

    /// <summary>
    /// Factory method to create a new product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public static Product Create(int? id, string name, string description, decimal price, int quantity, int categoryId)
    {
        var product = new Product
        {
            Id = id ?? default,
            Name = name,
            Description = description,
            Price = price,
            Quantity = quantity,
            CategoryId = categoryId
        };

        return product;
    }

    /// <summary>
    /// Update the product
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    /// <param name="categoryId"></param>
    public void Update(string name, string description, decimal price, int quantity, int categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        CategoryId = categoryId;
    }
}