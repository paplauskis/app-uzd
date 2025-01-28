using app_project.Data.Context;
using app_project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace app_project.Repository;

public class ResidentRepository : UserRepository<Resident>
{
    public ResidentRepository(PostgreContext context) : base(context) {}

    public IEnumerable<Resident> GetAllWithCommunities()
    {
        return Context.Residents
            .Include(r => r.Community)
            .ToList();
    }

    public Resident GetFullResidentInfo(Resident resident)
    {
        return Context.Residents
            .Include(r => r.Community)
            .ThenInclude(c => c.Services)
            .ThenInclude(s => s.ServiceType)
            .First(r => r.Id == resident.Id);
    }
}