using ComputerAPP.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.IRepos
{
    interface IDesktopRepo
    {
        Task<IEnumerable<Desktop>> GetAllDesktops();
        Task<Desktop> GetDesktopById(int id);
        Task<bool> AddDesktop(Desktop desktop);
        Task<bool> UpdateDesktop(Desktop desktop);
        Task<bool> DeleteDesktop(int id);
    }
}
