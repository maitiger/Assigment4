using System;
using System.ComponentModel.DataAnnotations;

namespace Redo.Models
{
    public class MyCredential
    {
        public MyCredential(long ownerId)
        {
            this.AccessToken = Guid.NewGuid().ToString();
            this.OwnerId = OwnerId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ExpireAt = DateTime.Now.AddDays(7);
            this.Status = MyCredentialStatus.Active;
        }
        public MyCredential(long ownerId, string scopeIds)
        {
            this.ScopeIds = scopeIds;
            this.AccessToken = Guid.NewGuid().ToString();
            this.OwnerId = OwnerId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ExpireAt = DateTime.Now.AddDays(7);
            this.Status = MyCredentialStatus.Active;
        }
        [Key]
        public string AccessToken { get; set; }

        public long OwnerId { get; set; }
        public string ScopeIds { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpireAt { get; set; }
        public MyCredentialStatus Status { get; set; }

        public bool isValid()
        {
            return (this.Status == MyCredentialStatus.Active && this.ExpireAt > DateTime.Now);
        }
    }

    public enum MyCredentialStatus
    {
        Active = 1,
        Deactive = 0
    }
}
