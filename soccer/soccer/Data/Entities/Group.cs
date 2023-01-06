using System.ComponentModel.DataAnnotations;

namespace soccer.Data.Entities
{
    public class Group
    {
        public int Id { get; set; }

        [Display(Name = "Grupo")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public Tournament Tournament { get; set; }
        public ICollection<GroupDetail> GroupDetails { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}
