using app_project.Data.Interfaces;
using app_project.Data.Models;
using app_project.Helpers;
using app_project.Services;

namespace app_project.UI;

public class ResidentUI : IUserUI
{
    private readonly ResidentService _residentService;

    public ResidentUI()
    {
        _residentService = new ResidentService(Session.CurrentUser);
    }
    
    public void Render()
    {
        int choice;
        
        do
        {
            _residentService.ShowInfo();
            ResidentLogger.LogOptions();
            choice = InputReader.ReadUserChoice();
        } while (!InputValidator.ResidentChoiceValid(choice.ToString()));

        Session.Logout();
    }
}