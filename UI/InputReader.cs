using app_project.Helpers;

namespace app_project.UI;

public static class InputReader
{
    public static int ReadMainWindowChoice()
    {
        string? input;
        
        do
        {
            input = Console.ReadLine();
        } while (!InputValidator.UserChoiceValid(input));

        return int.Parse(input);
    }
    
    public static int ReadUserChoice()
    {
        string? input;
        
        do
        {
            input = Console.ReadLine();
        } while (!InputValidator.AdminChoiceValid(input));

        return int.Parse(input);
    }

    public static string ReadUserInput(string prompt)
    {
        Console.WriteLine(prompt + ":");
        var input = Console.ReadLine();

        if (input == null)
        {
            Console.WriteLine("Input cannot be empty");
            ReadUserInput(prompt);
        }
        
        return input;
    }

    public static int ReadUserServiceTypeInput()
    {
        string? input;
        
        do
        {
            input = Console.ReadLine();
        } while (!InputValidator.ServiceTypeChoiceValid(input));

        return int.Parse(input);
    }

    public static int ReadUserNumberInput(string prompt)
    {
        Console.WriteLine(prompt + ":");
        string? input;
        int choice;
        
        do
        {
            input = Console.ReadLine();
        } while (!int.TryParse(input, out choice));

        return choice;
    }
}