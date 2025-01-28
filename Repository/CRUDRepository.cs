using app_project.Data.Context;
using app_project.Data.Interfaces;
using app_project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace app_project.Repository;

public abstract class CRUDRepository<T> : ICRUDRepository<T> where T : Entity
{
    protected readonly PostgreContext Context;

    protected CRUDRepository(PostgreContext context)
    {
        Context = context;
    }
    
    public virtual T GetById(int id)
    {
        var user = Context.Set<T>().Find(id);
        
        if (user != null)
        {
            return user;
        }
        
        throw new ArgumentNullException(id.ToString());
    }

    public virtual IEnumerable<T> GetAll()
    {
        return Context.Set<T>().ToList();
    }

    public virtual void Add(T entity)
    {
        Context.Set<T>().Add(entity);
        Context.SaveChanges();
    }

    public abstract void Update(T entity);

    public virtual void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
        Context.SaveChanges();
    }
}