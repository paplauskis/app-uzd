using app_project.Data.Context;
using app_project.Data.Models;
using app_project.Repository;
using app_project.UI;
using app_project.UI.Manager;

namespace app_project.Services;

public class ManagerService
{
    private static readonly PostgreContext _context = new();
    private readonly ManagerRepository _managerRepository = new(_context);
    private readonly ResidentRepository _residentRepository = new(_context);
    private readonly ServiceRepository _serviceRepository = new(_context);
    private readonly User _manager;

    public ManagerService(User manager)
    {
        _manager = manager;
    }

    public void ChangeServicePrice()
    {
        Console.WriteLine("Select a service to add to a community:");
        ManagerLogger.PrintAvailableServices();
        var type = InputReader.ReadUserServiceTypeInput();
        var price = InputReader.ReadUserNumberInput("Enter service price");
        var community = _managerRepository.GetCommunityByManagerId(_manager.Id);
        
        var service = new Service
        {
            Price = price,
            ServiceTypeId = type,
        };
        
        _serviceRepository.UpdatePrice(service, community);
        // _communityRepository.AddServiceToCommunity(community, service);
    }

    public void AddResident()
    {
        var name = InputReader.ReadUserInput("Enter resident name");
        var password = InputReader.ReadUserInput("Enter resident password");
        var houseSize = InputReader.ReadUserNumberInput("Enter resident house size");
        var community = _managerRepository.GetCommunityByManagerId(_manager.Id);
        
        var resident = new Resident
        {
            Username = name,
            Password = password,
            HouseSize = houseSize,
            CommunityId = community.Id
        };
        
        _residentRepository.Add(resident);
    }

    public void GetResidents()
    {
        var residents = _managerRepository.GetAllResidents(_manager);
        ManagerLogger.PrintResidents(residents);
    }

    public void GetServices()
    {
        var services = _managerRepository.GetAllServices(_manager);
        ManagerLogger.PrintServices(services);
    }

    public void GetCommunityInfo()
    {
        var community = _managerRepository.GetCommunityByManagerId(_manager.Id);
        ManagerLogger.PrintCommunityInfo(community);
    }
}