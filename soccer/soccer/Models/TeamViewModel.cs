using soccer.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace soccer.Models
{
    public class TeamViewModel:Team
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
