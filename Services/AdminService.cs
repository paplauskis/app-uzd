using app_project.Data.Context;
using app_project.Data.Models;
using app_project.Repository;
using app_project.UI;
using app_project.UI.Admin;

namespace app_project.Services;

public class AdminService
{
    private static readonly PostgreContext _context = new();
    private readonly AdminRepository _adminRepository = new(_context);
    private readonly ManagerRepository _managerRepository = new(_context);
    private readonly CommunityRepository _communityRepository = new(_context);
    private readonly ServiceRepository _serviceRepository = new(_context);
    private readonly ResidentRepository _residentRepository = new(_context);
    
    public void AddManager()
    {
        var name = InputReader.ReadUserInput("Enter manager name");
        var password = InputReader.ReadUserInput("Enter manager password");
        
        _managerRepository.Add(new Manager { Username = name, Password = password });
    }

    public void AddCommunity()
    {
        var name = InputReader.ReadUserInput("Enter community name");
        var city = InputReader.ReadUserInput("Enter community city");
        var street = InputReader.ReadUserInput("Enter community street");
        var houseNumber = InputReader.ReadUserInput("Enter community house number");
        
        _communityRepository.Add(new Community
        {
            Name = name,
            City = city,
            Street = street,
            HouseNumber = houseNumber,
        });
    }

    public void AddResident()
    {
        var name = InputReader.ReadUserInput("Enter resident name");
        var password = InputReader.ReadUserInput("Enter resident password");
        var houseSize = InputReader.ReadUserNumberInput("Enter resident house size");
        var communityName = InputReader.ReadUserInput("Enter community name which the resident will be added to");
        var community = _communityRepository.GetByName(communityName);
        
        _residentRepository.Add(new Resident()
        {
            Username = name, 
            Password = password, 
            HouseSize = houseSize, 
            CommunityId = community.Id
        });
    }

    public void UpdateManager()
    {
        var name = InputReader.ReadUserInput("Enter manager to be updated name");
        var manager = _managerRepository.GetByUsername(name);
        var newName = InputReader.ReadUserInput("Enter NEW name for manager");
        var newPassword = InputReader.ReadUserInput("Enter NEW password for manager");
        
        _managerRepository.Update(new Manager
        {
            Id = manager.Id, 
            Username = newName, 
            Password = newPassword,
            DateCreated = manager.DateCreated,
        });
    }

    public void UpdateCommunity()
    {
        var communityName = InputReader.ReadUserInput("Enter community name");
        var community = _communityRepository.GetByName(communityName);
        var newName = InputReader.ReadUserInput("Enter NEW name for community");
        var newCity = InputReader.ReadUserInput("Enter NEW community city");
        var newStreet = InputReader.ReadUserInput("Enter NEW community street");
        var newHouseNumber = InputReader.ReadUserInput("Enter NEW community house number");
        
        _communityRepository.Update(new Community
        {
            Id = community.Id,
            Name = newName,
            City = newCity,
            Street = newStreet,
            HouseNumber = newHouseNumber,
            DateCreated = community.DateCreated,
        });
    }

    public void AddServiceToCommunity()
    {
        Console.WriteLine("Select a service to add to a community:");
        AdminLogger.PrintAvailableServices();
        var type = InputReader.ReadUserServiceTypeInput();
        var communityName = InputReader.ReadUserInput("Enter community name to assign service");
        
        var community = _communityRepository.GetByName(communityName);
        var service = new Service
        {
            Price = 0,
            ServiceTypeId = type,
        };
        
        _serviceRepository.Add(service);
        _communityRepository.AddServiceToCommunity(community, service);
    }

    public void AddManagerToCommunity()
    {
        var managerName = InputReader.ReadUserInput("Enter manager name to be added to a community");
        var manager = _managerRepository.GetByUsername(managerName);
        
        var communityName = InputReader.ReadUserInput("Enter community name where manager will be added");
        var community = _communityRepository.GetByName(communityName);
        
        manager.CommunityId = community.Id;
        community.ManagerId = manager.Id;
        _managerRepository.Update(manager);
        _communityRepository.Update(community);
    }

    public void RemoveManagerFromCommunity()
    {
        var communityName = InputReader.ReadUserInput("Enter community name from which manager will be removed");
        var community = _communityRepository.GetByName(communityName);
        var managerName = InputReader.ReadUserInput("Enter manager name of the community");
        var manager = _managerRepository.GetByUsername(managerName);
        
        community.ManagerId = null;
        manager.CommunityId = null;
        
        _communityRepository.Update(community);
        _managerRepository.Update(manager);
    }

    public void RemoveServiceFromCommunity()
    {
        var communityName = InputReader.ReadUserInput("Enter community name from which a service will be removed");
        var community = _communityRepository.GetByName(communityName);
        var serviceId = InputReader.ReadUserNumberInput("Enter service id to be removed from the community");
        var service = _serviceRepository.GetById(serviceId);
        
        _serviceRepository.Delete(service);
    }

    public void DeleteManager()
    {
        var managerName = InputReader.ReadUserInput("Enter manager name to be deleted");
        var manager = _managerRepository.GetByUsername(managerName);
        _managerRepository.Delete(manager);
    }

    public void DeleteCommunity()
    {
        var communityName = InputReader.ReadUserInput("Enter community name to be deleted");
        var community = _communityRepository.GetByName(communityName);
        _communityRepository.Delete(community);
    }

    public void GetAllCommunities()
    {
        var communities = _communityRepository.GetAllWithManagersServicesAndResidents();
        AdminLogger.PrintCommunityList(communities);
    }

    public void GetAllManagers()
    {
        var managers = _managerRepository.GetAllWithCommunities();
        AdminLogger.PrintManagerList(managers);
    }

    public void GetAllResidents()
    {
        var residents = _residentRepository.GetAllWithCommunities();
        AdminLogger.PrintResidentList(residents);
    }
}