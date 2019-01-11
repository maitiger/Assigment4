using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Redo.Models
{
    public class Mark
    {
        [Key]
        public long IdMark { get; set; }
        [Range(0, 10, ErrorMessage = "Lưu Ý : điểm cho nằm trong khoảng từ 0 - 10 ")]
        public int Theory { get; set; }
        [Range(0, 15, ErrorMessage = "Lưu Ý : điểm cho nằm trong khoảng từ 0 -  15 ")]
        public int Practice { get; set; }
        [Range(0, 10, ErrorMessage = "Lưu Ý : điểm cho nằm trong khoảng từ 0 -  10 ")]
        public int Assignment { get; set; }
        public Student student { get; set; }
        public Subject subject { get; set; }
        public MarkStatus StatusMark { get; set; }

        public Mark()
            {

                if(this.Theory>=4 && this.Practice >= 4 && this.Assignment >= 4)
                {
                this.StatusMark = MarkStatus.Pass;
                }
                else
                {
                this.StatusMark = MarkStatus.Fail;

                }
            }
         
    }
    public enum MarkStatus
    {
        Pass = 1,
        Fail = 0
    }
}
