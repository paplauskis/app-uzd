using app_project.Data.Interfaces;
using app_project.Helpers;
using app_project.Services;

namespace app_project.UI.Manager;

public class ManagerUI : IUserUI
{
    private readonly ManagerService _managerService;
    
    public ManagerUI()
    {
        _managerService = new ManagerService(Session.CurrentUser);
    }
    
    public void Render()
    {
        int choice;
        
        do
        {
            do
            {
                ManagerLogger.LogOptions();
                choice = InputReader.ReadUserChoice();
            } while (!InputValidator.ManagerChoiceValid(choice.ToString()));

            switch (choice)
            {
                case 0: _managerService.ChangeServicePrice();
                    break;
                case 1: _managerService.AddResident();
                    break;
                case 2: 
                    _managerService.GetResidents();
                    break;
                case 3:
                    _managerService.GetServices();
                    break;
                case 4:
                    _managerService.GetCommunityInfo();
                    break;
            }
        } while (choice != 5);
        
        Session.Logout();
    }
}