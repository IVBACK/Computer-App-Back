using ComputerAPP.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.IRepos
{
    interface IDesktopRepo
    {
        void SaveChanges();
        IEnumerable<Desktop> GetAllDesktops();
        Desktop GetDesktopById(int id);
        bool CreateDesktop(Desktop desktop);
        bool UpdateDesktop(Desktop desktop);
        bool DeleteDesktop(int id);
    }
}
