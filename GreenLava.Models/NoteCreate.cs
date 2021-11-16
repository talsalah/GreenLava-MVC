using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Models
{
    public class NoteCreate
    {
        //  [Required]
       // public int NoteId { get; set; }
      //   public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
