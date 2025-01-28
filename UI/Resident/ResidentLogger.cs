using app_project.Data.Models;

namespace app_project.UI;

public class ResidentLogger
{
    public static void LogOptions()
    {
        Console.WriteLine("0. Exit");
    }
    public static void LogInfo(Resident resident)
    {
        Console.WriteLine("-----------------------\n");

        Console.Write("Name: " + resident.Username + "\n");
        Console.Write("House size: " + resident.HouseSize + "\n");
        Console.Write("Community info: " 
                      + resident.Community.Name + ", " 
                      + resident.Community.City + ", "
                      + resident.Community.Street + ", "
                      + resident.Community.HouseNumber + "\n");
        
        foreach (var service in resident.Community.Services)
        {
            Console.Write(service.ServiceType.Name + ", price: " + service.Price + "\n");
        }
        
        Console.WriteLine("\n-----------------------");
    }
}