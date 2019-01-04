using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Student
    {
        public Student()
        {
            this.Status = StudentStatus.Active;
            this.UpdateAt = DateTime.Now;
            this.Admission = DateTime.Now;
        }
        [Key]
        public long RollNumber { get; set; }
        [Required]

        public string FullName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Avartar { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string Phone { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; }
        public DateTime Admission { get; set; }// Ngày nhập học
        public DateTime UpdateAt { get; set; }
        // muốn thêm : số môn nợ , giới hạn thời gian trả nợ , Tốt nghiệp bằng gì
        public StudentStatus Status { get; set; }
    }
    public enum StudentStatus
    {
        Active = 0,
        Finish =1 ,
        Fail =2
    }
}
