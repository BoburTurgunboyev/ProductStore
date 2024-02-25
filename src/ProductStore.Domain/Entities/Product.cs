using System.ComponentModel.DataAnnotations;

namespace ProductStore.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    [MaxLength(250)]
    public string Name { get; set; }
    public string? Description { get; set; }
}
