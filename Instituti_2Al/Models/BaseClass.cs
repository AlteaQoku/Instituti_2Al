using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instituti_2Al.Models
{
    public abstract class BaseClass
    {
        [Key]
        public int Id { get; set; }

        public string? PersonId { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedById { get; set; } = string.Empty;
        public string? UpdatedById { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; }

        [ForeignKey("PersonId")]
        public virtual IdentityUser? Person { get; set; } 
        [ForeignKey("DeletedById")]
        public virtual IdentityUser? DeletedBy { get; set; }
        [ForeignKey("UpdatedById")]
        public virtual IdentityUser? UpdatedBy { get;set; }


    }
}
