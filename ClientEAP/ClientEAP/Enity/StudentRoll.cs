using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Enity
{
    class StudentRoll
    {
        private string _rollNumber;
        private Students _informations;

        public string rollNumber { get => _rollNumber; set => _rollNumber = value; }
        public Students informations { get => _informations; set => _informations = value; }
    }
}
