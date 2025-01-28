using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_project.Data.Models;

[Table("community")]
public class Community : Entity
{
    [Column("name")]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [Column("city")]
    [MaxLength(100)]
    public required string City { get; set; }
    
    [Column("street")]
    [MaxLength(100)]
    public required string Street { get; set; }
    
    [Column("house_number")]
    [MaxLength(10)]
    public required string HouseNumber { get; set; }
    
    [Column("manager_id")]
    public int? ManagerId { get; set; }

    public virtual List<Resident> Residents { get; set; } = new();
    
    public virtual List<Service> Services { get; set; } = new();
    
    [ForeignKey("ManagerId")]
    public virtual Manager Manager { get; set; }
}