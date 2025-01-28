using app_project.Data.Models;
using app_project.Repository;
using app_project.UI;

namespace app_project.Services.Login;

public class ManagerLoginService : LoginService<ManagerRepository>
{
    public ManagerLoginService(ManagerRepository repository) : base(repository)
    {
    }

    public override bool HandleLogin(string username, string password)
    {
        if (_repository.ValidateUser(username, password))
        {
            var manager = _repository.GetByUsername(username);
            Session.Login(manager);
            return true;
        }

        Console.WriteLine("Incorrect username or password");
        HandleLogin(
            InputReader.ReadUserInput("Username"),
            InputReader.ReadUserInput("Password"));
        
        return false;
    }
}