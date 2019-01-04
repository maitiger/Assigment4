using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        [ForeignKey("MarkId")]
        public Mark mark { get; set; }
       
    }
}
