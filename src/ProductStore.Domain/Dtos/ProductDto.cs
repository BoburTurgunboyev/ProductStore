using System.ComponentModel.DataAnnotations;

namespace ProductStore.Domain.Dtos;

public class ProductDto
{
    [MaxLength(250)]
    public string Name { get; set; }
    public string? Description { get; set; }
}
