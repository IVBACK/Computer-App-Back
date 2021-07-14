using ComputerAPP.CORE.Models;
using System.Collections.Generic;

namespace ComputerAPP.SERVICE
{
    public interface INoteBookRepo
    {
        void SaveChanges();
        IEnumerable<NoteBook> GetAllNoteBooks();
        NoteBook GetNoteBookById(int id);
        void CreateNoteBook(NoteBook noteBook);
        void UpdateNoteBook(int id, NoteBook noteBook);
        void DeleteNoteBook(int id);
    }
}
