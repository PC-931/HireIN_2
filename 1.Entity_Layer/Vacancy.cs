using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Entity_Layer
{
    public class Vacancy
    {
        [Key]
        public int VacancyId { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string JobDescription { get; set; }

        [Required]
        public string JobLocation { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
