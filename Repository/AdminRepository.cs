using app_project.Data.Context;
using app_project.Data.Models;

namespace app_project.Repository;

public class AdminRepository : UserRepository<Admin>
{
    public AdminRepository(PostgreContext context) : base(context) {}
}