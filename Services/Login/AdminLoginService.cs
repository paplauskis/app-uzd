using app_project.Data.Models;
using app_project.Repository;
using app_project.UI;

namespace app_project.Services.Login;

public class AdminLoginService : LoginService<AdminRepository>
{
    public AdminLoginService(AdminRepository repository) : base(repository)
    {
    }
    
    public override bool HandleLogin(string username, string password)
    {
        if (_repository.ValidateUser(username, password))
        {
            var admin = _repository.GetByUsername(username);
            Session.Login(admin);
            return true;
        }

        Console.WriteLine("Incorrect username or password");
        HandleLogin(
            InputReader.ReadUserInput("Username"),
            InputReader.ReadUserInput("Password"));
        
        return false;
    }
}