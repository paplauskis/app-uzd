namespace app_project.Helpers;

public static class InputValidator
{
    public static bool UserChoiceValid(string? userInput)
    {
        if (userInput == null) return false;
        
        if (int.TryParse(userInput, out int choice) && choice is >= 0 and <= 3)
        {
            return true;
        }

        Console.WriteLine("Invalid input.");
        return false;
    }

    public static bool AdminChoiceValid(string? adminInput)
    {
        if (string.IsNullOrWhiteSpace(adminInput)) return false;
    
        if (int.TryParse(adminInput.Trim(), out int choice) && choice is >= 0 and <= 14)
        {
            return true;
        }

        Console.WriteLine("Invalid input.");
        return false;
    }
    
    public static bool ManagerChoiceValid(string? managerInput)
    {
        if (string.IsNullOrWhiteSpace(managerInput)) return false;
    
        if (int.TryParse(managerInput.Trim(), out int choice) && choice is >= 0 and <= 5)
        {
            return true;
        }

        Console.WriteLine("Invalid input.");
        return false;
    }
    
    public static bool ServiceTypeChoiceValid(string? userInput)
    {
        if (userInput == null) return false;
        
        if (int.TryParse(userInput, out int choice) && choice is >= 1 and <= 7)
        {
            return true;
        }

        Console.WriteLine("Invalid input.");
        return false;
    }

    public static bool ResidentChoiceValid(string? userInput)
    {
        if (userInput == null) return false;
        
        return userInput.Trim() == "0";
    }
}