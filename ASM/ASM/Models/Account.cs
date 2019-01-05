using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class Account 
    {
        private readonly MD5 _algorithm = MD5.Create();
        public Account()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = AccountStatus.Active;
            this.Role = Role.Student;
        }
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AccountStatus Status { get; set; }
        public Student student { get; set; }
        public Role Role { get; set; }
        // tạo muối, tạo chuỗi random sử dụng GUID.
        public void GenerateSalt()
        {
            this.Salt = Guid.NewGuid().ToString();
        }
        // mã hóa mật khẩu kèm theo muối. Lưu ý là mật khẩu với muối đều có trong đối tượng hiện tại.
        public void EncryptPassword()
        {
            this.Password += this.Salt;
            this.Password = EncryptString(this.Password);
        }
        // mã hóa chuỗi sử dụng thuật toán đã tạo ở trên.
        public string EncryptString(string stringToEncrypt)
        {
            var hash = _algorithm.ComputeHash(Encoding.UTF8.GetBytes(stringToEncrypt));
            return Convert.ToBase64String(hash);
        }
        // kiểm tra so sánh thông tin mật khẩu khi login, mật khẩu này sẽ được mã hóa
        // kèm muối ở trong database và so sanh với mật khẩu đã mã hóa trước đó.
        public bool CheckLoginPassword(string loginPassword)
        {
            loginPassword += this.Salt;
            loginPassword = EncryptString(loginPassword);
            return loginPassword == this.Password;
        }
    }
    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }
    public enum Role
    {
        Student =1,
        Ministry =0
    }

}
