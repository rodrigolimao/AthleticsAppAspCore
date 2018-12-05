using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaEco.Models
{
    [Table("Athletes")]
    public class Athlete
    {
        [Key]
        [Display(Name = "Athlete's ID")]
        public int athlete_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Athlete's Name")]
        public String athlete_name { get; set; }

        [Display(Name = "Athlete's Age")]
        public int athlete_age { get; set; }

        [Display(Name = "Sport ID")]
        public int sport_id { get; set; }


    }
}
