using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_project.Data.Models;

public abstract class Entity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("created_at")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}