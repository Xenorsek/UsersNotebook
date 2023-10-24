using UserNotebook.Core.Models;

namespace UserNotebook.Core.Services
{
    public interface IReportService
    {
        byte[] GenerateUserReport(List<UserDto> users);
    }
}