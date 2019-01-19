using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Enity
{
    class ListClass
    {
        private int _id;
        private string _name;
        private string _class;
        private string _email;
        private string _address;
        private string _birthday;
        public int id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string classname { get => _class; set => _class = value; }
        public string email { get => _email; set => _email = value; }
        public string address { get => _address; set => _address = value; }
        public string birthday { get => _birthday; set => _birthday = value; }
    }
}
