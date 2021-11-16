using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Models
{
    public class PersonCreate
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public DateTime DateJoined { get; set; }
        public string Hobby { get; set; }
    }
}
