using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaEco.Models
{
    [Table("Athletes")]
    public class Sport

    {
        [Key]
        [Display(Name = "Sport ID")]
        public int sport_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Sport Name")]
        public String sport_name { get; set; }

        [Display(Name = "Sport Rating")]
        public int sport_rating { get; set; }

        [Display(Name = "Sport Awards")]
        public int sport_awards { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }

    }
}
