using app_project.Data.Interfaces;

namespace app_project.UI;

public class UIContext
{
    private IUserUI _userUI;

    public UIContext(IUserUI userUI)
    {
        _userUI = userUI;
    }

    public void Render()
    {
        _userUI.Render();
    }
}