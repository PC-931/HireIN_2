using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Entity_Layer
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

        [Required]
        public string CandidateId { get; set; }

        [Required]
        public int VacancyId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
