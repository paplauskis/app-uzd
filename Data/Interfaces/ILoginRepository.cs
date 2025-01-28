namespace app_project.Data.Interfaces;

public interface ILoginRepository
{
    public bool ValidateUser(string username, string password);
}