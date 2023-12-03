using _1.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data_Layer.Services
{
    public class ApplicantDataService
    {
        private ApplicantServices _services;

        public ApplicantDataService()
        {
            _services = new ApplicantServices();
        }

        public bool CreateApplicant(Applicant appl)
        {
            return _services.Create(appl);
        }

        public bool DeleteApplicant(int id)
        {
            return _services.Delete(id);
        }

        public Applicant ShowApplicantDetails(int id)
        {
            return _services.Read(id);
        }

        public List<Applicant> ListAllApplicant()
        {
            return _services.ReadAll();
        }

        public bool UpdateVacancy(Applicant appl)
        {
            return _services.Update(appl);
        }

    }
}
