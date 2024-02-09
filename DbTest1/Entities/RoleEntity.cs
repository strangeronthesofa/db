using System.ComponentModel.DataAnnotations;

namespace DbTest1.Entities;

internal class RoleEntity
{
    [Key]
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;
}
