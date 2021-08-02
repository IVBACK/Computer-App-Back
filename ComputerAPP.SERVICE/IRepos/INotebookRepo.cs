using ComputerAPP.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.IRepos
{
    interface INotebookRepo
    {
        void SaveChanges();
        IEnumerable<NoteBook> GetAllNotebooks();
        NoteBook GetNotebookById(int id);
        bool CreateNotebook(NoteBook notebook);
        bool UpdateNotebook(NoteBook notebook);
        bool DeleteNotebook(int id);
    }
}
