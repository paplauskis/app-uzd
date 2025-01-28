using app_project.Data.Context;
using app_project.Data.Interfaces;
using app_project.Repository;
using app_project.Services.Login;
using app_project.UI;
using app_project.UI.Admin;
using app_project.UI.Manager;

while (true)
{
    Logger.Greet();
    int choice = InputReader.ReadMainWindowChoice();

    if (choice == 3) Environment.Exit(0);

    var username = InputReader.ReadUserInput("Username");
    var password = InputReader.ReadUserInput("Password");
    
    ILoginService loginService;
    IUserUI userUI;

    switch (choice)
    {
        case 0:
            loginService = new AdminLoginService(new AdminRepository(new PostgreContext()));
            loginService.HandleLogin(username, password);
            userUI = new AdminUI();
            break;
        case 1:
            loginService = new ManagerLoginService(new ManagerRepository(new PostgreContext()));
            loginService.HandleLogin(username, password);
            userUI = new ManagerUI();
            break;
        case 2:
            loginService = new ResidentLoginService(new ResidentRepository(new PostgreContext()));
            loginService.HandleLogin(username, password);
            userUI = new ResidentUI();
            break;
        default:
            throw new ArgumentException("Invalid user type.");
    }

    UIContext context = new UIContext(userUI);
    context.Render();
}