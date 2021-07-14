using ComputerAPP.CORE.Models;
using System.Collections.Generic;

namespace ComputerAPP.SERVICE
{
    interface IDesktopRepo
    {
        void SaveChanges();
        IEnumerable<Desktop> GetAllDesktops();
        Desktop GetDesktopById(int id);
        void CreateDesktop(Desktop desktop);
        void UpdateDesktop(int id, Desktop desktop);
        void DeleteDesktop(int id);
    }
}
