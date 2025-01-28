using app_project.Data.Context;
using app_project.Data.Models;

namespace app_project.Repository;

public class ServiceRepository : CRUDRepository<Service>
{
    public ServiceRepository(PostgreContext context) : base(context) {}
    
    public void UpdatePrice(Service service, Community community)
    {
        var serviceToBeUpdated = community.Services
            .First(s => s.ServiceTypeId == service.ServiceTypeId);
        
        serviceToBeUpdated.Price = service.Price;
        Context.SaveChanges();
    }

    public override void Update(Service entity)
    {
        throw new NotImplementedException();
    }
}