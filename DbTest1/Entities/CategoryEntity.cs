using System.ComponentModel.DataAnnotations;

namespace DbTest1.Entities;

internal class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}
