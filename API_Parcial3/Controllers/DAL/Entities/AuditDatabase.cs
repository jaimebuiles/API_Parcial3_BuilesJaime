using System.ComponentModel.DataAnnotations;

namespace API_Parcial3.Controllers.DAL.Entities
{
    public class AuditDatabase
    {
        [Key]
        [Required]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime ModifiDate { get; set; }
    }
}
