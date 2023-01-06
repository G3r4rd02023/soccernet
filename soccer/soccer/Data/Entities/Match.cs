using System.ComponentModel.DataAnnotations;

namespace soccer.Data.Entities
{
    public class Match
    {
        public int Id { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }
        public Team Local { get; set; }
        public Team Visitor { get; set; }

        [Display(Name = "Local")]
        public int GoalsLocal { get; set; }

        [Display(Name = "Visita")]
        public int GoalsVisitor { get; set; }

        [Display(Name = "Cerrado?")]
        public bool IsClosed { get; set; }

        public Group Group { get; set; }

    }
}
