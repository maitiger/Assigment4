using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Redo.Models
{
    public class FptCredential
    {
        public FptCredential(long ownerId)
        {
            this.AccessToken = Guid.NewGuid().ToString();
            this.OwnerId = OwnerId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ExpireAt = DateTime.Now.AddDays(7);
            this.Status = FptCredentialStatus.Active;
        }
        public FptCredential(long ownerId, string scopeIds)
        {
            this.ScopeIds = scopeIds;
            this.AccessToken = Guid.NewGuid().ToString();
            this.OwnerId = OwnerId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ExpireAt = DateTime.Now.AddDays(7);
            this.Status = FptCredentialStatus.Active;
        }
        [Key]
        public string AccessToken { get; set; }

        public long OwnerId { get; set; }
        public string ScopeIds { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpireAt { get; set; }
        public FptCredentialStatus Status { get; set; }

        public bool isValid()
        {
            return (this.Status == FptCredentialStatus.Active && this.ExpireAt > DateTime.Now);
        }
    }

    public enum FptCredentialStatus
    {
        Active = 1,
        Deactive = 0
    }
}
