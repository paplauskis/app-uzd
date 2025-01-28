using System.ComponentModel.DataAnnotations.Schema;

namespace app_project.Data.Models;

[Table(("resident"))]
public class Resident : User
{
    [Column("house_size")]
    public decimal HouseSize { get; set; } //size in square meters
    
    [Column("community_id")]
    public int CommunityId { get; set; }
    
    public virtual Community Community { get; set; }
}