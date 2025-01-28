using app_project.Data.Models;

namespace app_project.Data.Interfaces;

public interface ICRUDRepository<T> where T : Entity
{
    public T GetById(int id);
    public IEnumerable<T> GetAll();
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}