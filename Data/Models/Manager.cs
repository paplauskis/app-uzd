using System.ComponentModel.DataAnnotations.Schema;

namespace app_project.Data.Models;

[Table("manager")]
public class Manager : User
{
    [Column("community_id")]
    public int? CommunityId { get; set; }

    [ForeignKey("CommunityId")]
    public virtual Community Community { get; set; }
}