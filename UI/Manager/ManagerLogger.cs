using app_project.Data.Enums;
using app_project.Data.Interfaces;
using app_project.Data.Models;

namespace app_project.UI.Manager;

public class ManagerLogger : IUILogger
{
    public static void LogOptions()
    {
        Console.WriteLine("0. Change service price");
        Console.WriteLine("1. Add resident to community");
        Console.WriteLine("2. View all residents");
        Console.WriteLine("3. View all services");
        Console.WriteLine("4. View community info");
        Console.WriteLine("5. Exit");
    }

    public static void PrintResidents(IEnumerable<Resident> residents)
    {
        Console.WriteLine("---------------------------\n");
        Console.Write("Residents: \n");
        
        foreach (var resident in residents)
        {
            Console.Write(resident.Username + ", " + "house size: " + resident.HouseSize + "\n");
        }
        
        Console.WriteLine("\n---------------------------");
    }

    public static void PrintServices(IEnumerable<Service> services)
    {
        Console.WriteLine("---------------------------\n");
        Console.Write("Residents: \n");
        
        foreach (var service in services)
        {
            Console.Write(service.ServiceType.Name + ", price: " + service.Price + "\n");
        }
        
        Console.WriteLine("\n---------------------------");
    }

    public static void PrintCommunityInfo(Community community)
    {
        Console.WriteLine("---------------------------\n");
        Console.Write("Name: " + community.Name + "\n");
        Console.Write("City: " + community.City + "\n");
        Console.Write("Street: " + community.Street + "\n");
        Console.Write("House number: " + community.HouseNumber + "\n");
        Console.WriteLine("\n---------------------------");
    }

    public static void PrintAvailableServices()
    {
        var serviceTypes = Enum.GetValues(typeof(ServiceTypeE));

        foreach (var type in serviceTypes)
        {
            Console.WriteLine((int)type + ". " + type);
        }
    }
}