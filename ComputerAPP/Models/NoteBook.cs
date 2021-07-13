using ComputerAPP.ModelValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerAPP
{
    [NoteBook_EnsureFieldsAreNotEmpty]
    public class NoteBook
    {
        public int? NoteBookId { get; set; }

        [Required]
        public string Brand { get; set; }
        
        [Required]
        public string Model { get; set; }

        [Required]
        public string Cpu { get; set; }

        [Required]
        public string Gpu { get; set; }

        [Required]
        public string Ram { get; set; }

        [Required]
        public string Battery { get; set; }
    }
}
