using app_project.Data.Context;
using app_project.Data.Models;
using app_project.Repository;
using app_project.UI;

namespace app_project.Services;

public class ResidentService
{
    private static readonly PostgreContext _context = new();
    private readonly ResidentRepository _residentRepository = new(_context);
    private readonly User _resident;
    
    public ResidentService(User resident)
    {
        _resident = resident;
    }

    public void ShowInfo()
    {
        var resident = _residentRepository.GetById(_resident.Id);
        var residentFullInfo = _residentRepository.GetFullResidentInfo(resident);
        ResidentLogger.LogInfo(residentFullInfo);
    }
}