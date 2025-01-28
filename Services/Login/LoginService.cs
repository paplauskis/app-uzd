using System.Reflection.Metadata;
using app_project.Data.Interfaces;
using app_project.Data.Models;
using app_project.Repository;
using app_project.UI;

namespace app_project.Services.Login;

public abstract class LoginService<T> : ILoginService where T : ILoginRepository
{
    protected readonly T _repository;

    public LoginService(T repository)
    {
        _repository = repository;
    }

    public abstract bool HandleLogin(string username, string password);
}