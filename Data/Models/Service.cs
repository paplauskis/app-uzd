using System.ComponentModel.DataAnnotations.Schema;

namespace app_project.Data.Models;

[Table("service")]
public class Service : Entity
{
    private decimal _price;

    [Column("price")]
    public required decimal Price
    {
        get => _price;
        set => _price = Math.Round(value, 2);
    }
    
    [Column("service_type_id")]
    public int ServiceTypeId { get; set; }
    
    public virtual List<Community> Communities { get; set; }
    
    [ForeignKey("ServiceTypeId")]
    public virtual ServiceType ServiceType { get; set; }
}
