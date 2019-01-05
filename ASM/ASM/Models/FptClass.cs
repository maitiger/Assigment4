using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class FptClass
    {
        public FptClass()
        {
            this.UpdateAt = DateTime.Now;
            this.OpenAt = DateTime.Now;
            this.Status = FptClassStatus.Open;
        }
        public long Id { get; set; }
        public string Teacher { get; set; }
        public Subject subject { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public FptClassStatus Status { get; set; }
    }
    public enum FptClassStatus
    {
        Open = 1,
        Finish =0
    }
}
