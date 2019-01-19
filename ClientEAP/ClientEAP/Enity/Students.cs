using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Enity
{
    public class Students
    {
        private int _id;
        private string _name;
        private string _class;       
        private string _email;
        private string _password;
        private string _address;
        private string _avatar;
        private string _phone;
        private int _gender;
        private DateTime _birthday;
        private string _createaAt;
        private string _updateAt;
        private int _status;
        private string _mark;
   

        public int id {  get => _id; set => _id = value; }
        public string name { get => _name ; set => _name = value; }
        public string Class { get => _class; set => _class = value; }
        public string email { get => _email; set =>  _email = value; }
        public string password { get => _password; set => _password = value; }
        public string address { get => _address; set => _address = value; }
        public  string avatar  { get => _avatar ; set => _avatar = value; }
        private string phone { get => _phone; set => _phone = value; }
        public int  gender { get  => _gender ; set => _gender = value; }
        public DateTime birthday { get => _birthday; set => _birthday = value; }
        public string createAt { get => _createaAt; set => _createaAt = value; }
        public string updateAt { get => _updateAt ; set => _updateAt = value; }
        public  int status { get => _status; set => _status = value; }
        public  string mark { get => _mark; set => _mark = value; }
 



    }
}
