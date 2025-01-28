using app_project.Data.Models;

namespace app_project;

public static class Session
{
    public static User? CurrentUser { get; private set; }

    public static void Login(User user)
    {
        CurrentUser = user;
    }

    public static void Logout()
    {
        CurrentUser = null;
    }
}