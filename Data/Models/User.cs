using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_project.Data.Models;

public abstract class User : Entity
{
    [Column("username")]
    [MaxLength(100)]
    public required string Username { get; set; }
    
    [Column("password")]
    [MaxLength(100)]
    public required string Password { get; set; }
}