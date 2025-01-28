using app_project.Data.Interfaces;
using app_project.Helpers;
using app_project.Services;

namespace app_project.UI.Admin;

public class AdminUI : IUserUI
{
    private readonly AdminService _adminService = new();
    
    public void Render()
    {
        int choice;
        
        do
        {
            do
            {
                AdminLogger.LogOptions();
                choice = InputReader.ReadUserChoice();
            } while (!InputValidator.AdminChoiceValid(choice.ToString()));

            switch (choice)
            {
                case 0: _adminService.AddManager();
                    break;
                case 1: _adminService.AddCommunity();
                    break;
                case 2: 
                    _adminService.AddResident();
                    break;
                case 3:
                    _adminService.UpdateManager();
                    break;
                case 4: 
                    _adminService.UpdateCommunity();
                    break;
                case 5:
                    _adminService.AddServiceToCommunity();
                    break;
                case 6:
                    _adminService.AddManagerToCommunity();
                    break;
                case 7:
                    _adminService.RemoveManagerFromCommunity();
                    break;
                case 8:
                    _adminService.RemoveServiceFromCommunity();
                    break;
                case 9:
                    _adminService.DeleteManager();
                    break;
                case 10:
                    _adminService.DeleteCommunity();
                    break;
                case 11:
                    _adminService.GetAllCommunities();
                    break;
                case 12:
                    _adminService.GetAllManagers();
                    break;
                case 13:
                    _adminService.GetAllResidents();
                    break;
            }
        } while (choice != 14);
        
        Session.Logout();
    }
}