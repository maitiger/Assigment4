using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class Subject 
    {
        public Subject()
        {
            this.Status = SubjectStatus.Active;
           
        }
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Teacher { get; set; }
        public SubjectStatus Status { get; set; }
        public ICollection<Mark> mark { get; set; }

    }
    public enum SubjectStatus
    {
        Active = 1,
        Deactive =0
    }
   
}
