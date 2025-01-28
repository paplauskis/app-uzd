using app_project.Data.Context;
using app_project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace app_project.Repository;

public class ManagerRepository : UserRepository<Manager>
{
    public ManagerRepository(PostgreContext context) : base(context) {}

    public override void Update(Manager manager)
    {
        var userToUpdate = GetById(manager.Id);
        
        userToUpdate.Username = manager.Username;
        userToUpdate.Password = manager.Password;
        userToUpdate.CommunityId = manager.CommunityId;
        Context.SaveChanges();
    }

    public IEnumerable<Manager> GetAllWithCommunities()
    {
        return Context.Managers
            .Include(m => m.Community)
            .ToList();
    }

    public IEnumerable<Resident> GetAllResidents(User manager)
    {
        var community = Context.Communities
            .Include(community => community.Residents)
            .First(c => c.ManagerId == manager.Id);
        
        return community.Residents;
    }

    public IEnumerable<Service> GetAllServices(User manager)
    {
        return Context.Communities
            .Include(c => c.Services)
            .ThenInclude(s => s.ServiceType)
            .First(c => c.ManagerId == manager.Id).Services;
    }

    public Community GetCommunityByManagerId(int managerId)
    {
        return Context.Communities
            .Include(c => c.Services)
            .First(c => c.ManagerId == managerId);
    }
}