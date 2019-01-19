using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Enity
{
    class Crendential
    {
        private string _accessToken;
        private long _ownerId;
        private DateTime _createdAt;
        private DateTime _updatedAt;
        private DateTime _expiredAt;
        private long _status;

        public string accessToken { get => _accessToken; set => _accessToken = value; }
        public long ownerId { get => _ownerId; set => _ownerId = value; }
        public DateTime createdAt { get => _createdAt; set => _createdAt = value; }
        public DateTime updatedAt { get => _updatedAt; set => _updatedAt = value; }
        public DateTime expiredAt { get => _expiredAt; set => _expiredAt = value; }
        public long status { get => _status; set => _status = value; }
    }
}
