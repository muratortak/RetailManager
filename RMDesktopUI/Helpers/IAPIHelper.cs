using RMDesktopUI.Models;
using System.Threading.Tasks;

namespace RMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticateUser> Authenticate(string username, string password);
    }
}