namespace app_project.Data.Interfaces;

public interface ILoginService
{
    public bool HandleLogin(string username, string password);
}