using System.Collections.Generic;
using ProductManagement.Domain.Common;

namespace ProductManagement.Domain.Entities;

public class Category : AuditableBaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int? ParentId { get; private set; }
    public Category Parent { get; set; }

    private readonly List<Category> _children;
    public IEnumerable<Category> Children => _children.AsReadOnly();
   
    public IEnumerable<Product> Products { get; set; }

    protected Category()
    {
        _children = new List<Category>();
    }
    

    /// <summary>
    /// Factory method to create a new category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public static Category Create(int? id, string name, string description, int? parentId)
    {
        var category = new Category
        {
            Id = id ?? default,
            Name = name,
            Description = description,
            ParentId = parentId,
        };

        return category;
    }

    /// <summary>
    /// Method to update the category
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="parentId"></param>
    public void Update(string name, string description, int? parentId)
    {
        Name = name;
        Description = description;
        ParentId = parentId;
    }
}