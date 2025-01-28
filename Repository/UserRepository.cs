using app_project.Data.Context;
using app_project.Data.Interfaces;
using app_project.Data.Models;

namespace app_project.Repository;

public abstract class UserRepository<T> : CRUDRepository<T>, ILoginRepository where T : User
{
    protected UserRepository(PostgreContext context) : base(context)
    {
    }
    
    public override void Update(T user)
    {
        var userToUpdate = GetById(user.Id);
        
        userToUpdate.Username = user.Username;
        userToUpdate.Password = user.Password;
        Context.SaveChanges();
    }
    
    public virtual T? GetByUsername(string username)
    {
        return Context.Set<T>().SingleOrDefault(u => u.Username == username);
    }

    public bool ValidateUser(string username, string password)
    {
        return Context.Set<T>().Any(user => user.Username == username && user.Password == password);
    }

}