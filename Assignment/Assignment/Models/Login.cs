using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Login : Student
    {
              [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
