using app_project.Data.Enums;
using app_project.Data.Interfaces;
using app_project.Data.Models;

namespace app_project.UI.Admin;

public class AdminLogger : IUILogger
{
    public static void LogOptions()
    {
        Console.WriteLine("0. Add manager");
        Console.WriteLine("1. Add community");
        Console.WriteLine("2. Add resident");
        Console.WriteLine("3. Edit manager");
        Console.WriteLine("4. Edit community");
        Console.WriteLine("5. Add service to community");
        Console.WriteLine("6. Add manager to community");
        Console.WriteLine("7. Remove manager from community");
        Console.WriteLine("8. Remove service from community");
        Console.WriteLine("9. Delete manager");
        Console.WriteLine("10. Delete community");
        Console.WriteLine("11. View all communities");
        Console.WriteLine("12. View all managers");
        Console.WriteLine("13. View all residents");
        Console.WriteLine("14. Exit");
    }

    public static void PrintUserList(IEnumerable<User> entities)
    {
        foreach (var entity in entities)
        {
            Console.WriteLine("-- " + entity.Username + " " + entity.Password + " --");
        }
    }

    public static void PrintCommunityList(IEnumerable<Community> communities)
    {
        foreach (var community in communities)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-- " + community.Name + ", " 
                              + community.City + ", "
                              + community.Street + ", " 
                              + community.HouseNumber + ", "
                              + "MANAGER: " + (community.ManagerId != null ? community.Manager.Username : "no manager") + " --\n");
            
            if (community.Services != null)
            {
                Console.Write("SERVICES: ");
            
                foreach (var service in community.Services)
                {
                    Console.Write(service.ServiceType.Name + ", ");
                }
            }

            if (community.Residents != null)
            {
                Console.Write("\nRESIDENTS: ");
                
                foreach (var resident in community.Residents)
                {
                    Console.Write(resident.Username + ", ");
                }
            }
            Console.WriteLine("\n-------------------------------");
        }
    }

    public static void PrintServiceList(IEnumerable<Service> services)
    {
        foreach (var service in services)
        {
            Console.WriteLine("-- " + service.ServiceType.Name + ", " + service.Price + " --");   
        }
    }

    public static void PrintAvailableServices()
    {
        var serviceTypes = Enum.GetValues(typeof(ServiceTypeE));

        foreach (var type in serviceTypes)
        {
            Console.WriteLine((int)type + ". " + type);
        }
    }

    public static void PrintManagerList(IEnumerable<Data.Models.Manager> managers)
    {
        foreach (var manager in managers)
        {
            Console.WriteLine("-- " + manager.Username 
                                    + "; " + "COMMUNITY: " 
                                    + (manager.Community != null 
                                        ? manager.Community.Name 
                                        : "no community") + " --");
        }
    }

    public static void PrintResidentList(IEnumerable<Resident> residents)
    {
        foreach (var resident in residents)
        {
            Console.WriteLine("-- " + resident.Username 
                                    + "; house size: " + resident.HouseSize
                                    + "; " + "COMMUNITY: " 
                                    + resident.Community.Name 
                                    + " --");
        }
    }
}