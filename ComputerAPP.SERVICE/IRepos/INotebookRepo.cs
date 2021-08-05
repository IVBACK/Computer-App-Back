using ComputerAPP.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE
{
    interface INotebookRepo
    {
        Task<IEnumerable<Notebook>> GetAllNotebooks();
        Task<Notebook> GetNotebookById(int id);
        IEnumerable<Notebook> SearchNotebooks(string search);
        Task<bool> AddNotebook(Notebook notebook);
        Task<bool> UpdateNotebook(Notebook notebook);
        Task<bool> DeleteNotebook(int id);
    }
}