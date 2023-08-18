using System.Collections.Generic;
using System.Linq;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.DTOs.Categories;

public record CategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int? ParentId { get; set; }
    public IEnumerable<CategoryDto> Children { get; set; }

    //use explicit operator to map from Category to CategoryDto (I prefer this way that using AutoMapper)
    public static explicit operator CategoryDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ParentId = category.ParentId,
            Children = category.Children.Select(c => (CategoryDto)c)
        };
    }
}    