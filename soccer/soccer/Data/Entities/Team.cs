using System.ComponentModel.DataAnnotations;

namespace soccer.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = "Equipo")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }
        public ICollection<GroupDetail> GroupDetails { get; set; }
    }
}
