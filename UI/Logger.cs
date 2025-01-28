namespace app_project.UI.Admin;

public static class Logger
{
    public static void Greet()
    {
        Console.WriteLine("Welcome to utility management system");
        Console.WriteLine("Enter a number for logging in:");
        Console.WriteLine("0. Admin");
        Console.WriteLine("1. Manager");
        Console.WriteLine("2. Resident");
        Console.WriteLine("3. Exit");
    }
}