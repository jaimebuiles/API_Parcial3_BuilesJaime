using System.ComponentModel.DataAnnotations;

namespace API_Parcial3.Controllers.DAL.Entities
{
    public class Task : AuditDatabase
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Titulo")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} character")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String Title { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "The campo {0} must have a maximum of {1} character")]
        public String Description { get; set; }

        [Display(Name = "Completado")]
        [Required(ErrorMessage = "Field {0} requires yes or no")]
        public Boolean IsCompleted { get; set; }

        [Display(Name = "Prioridad")]
        [MaxLength(50, ErrorMessage = "The field {0} requires the assignment of  (High, Medium, Low)")]
        [Required]
        public String Priority { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        [Required]
        public DateTime DueDate { get; set; }

        [Display(Name = "Fecha Creación")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Fecha Finalización")]
        public DateTime CompletionDate { get; set; }
    }
}
