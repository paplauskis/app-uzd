using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_project.Data.Models;

[Table("service_type")]
public class ServiceType : Entity
{
    [Column("name")]
    [MaxLength(30)]
    public string Name { get; set; }
    
    public virtual List<Service> Services { get; set; }
}
