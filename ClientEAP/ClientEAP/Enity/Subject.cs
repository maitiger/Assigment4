using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Enity
{
    class Subject
    {
        private int _id;
        private string _name;
        public int id { get => _id ; set => _id = value; }
        public string name { get => _name; set => _name = value; }
    }
}
