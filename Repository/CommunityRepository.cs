using app_project.Data.Context;
using app_project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace app_project.Repository;

public class CommunityRepository : CRUDRepository<Community>
{
    public CommunityRepository(PostgreContext context) : base(context) {}


    public override void Update(Community com)
    {
        var comToUpdate = Context.Communities.Find(com.Id);
        
        comToUpdate.Name = com.Name;
        comToUpdate.City = com.City;
        comToUpdate.Street = com.Street;
        comToUpdate.HouseNumber = com.HouseNumber;
        comToUpdate.ManagerId = com.ManagerId;

        Context.SaveChanges();
    }

    public Community GetByName(string name)
    {
        return Context.Communities.First(x => x.Name == name);
    }

    public void AddServiceToCommunity(Community community, Service service)
    {
        community.Services.Add(service);
        Context.SaveChanges();
    }
    
    public IEnumerable<Community> GetAllWithManagersServicesAndResidents()
    {
        return Context.Communities
            .Include(c => c.Manager)
            .Include(q => q.Services)
            .ThenInclude(s => s.ServiceType)
            .Include(r => r.Residents)
            .ToList();
    }
}