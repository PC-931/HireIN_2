using _1.Entity_Layer;
using System.Collections.Generic;

namespace _2.Data_Layer.Services
{
    public class VacancyDataService
    {
        private VacancyServices _services;

        public VacancyDataService()
        {
            _services = new VacancyServices();
        }

        public bool CreateVacancy( Vacancy vac)
        {
            return _services.Create(vac);
        }

        public bool DeleteVacancy( int id)
        {
            return _services.Delete(id);
        }

        public Vacancy ShowVacancyDetails(int id)
        {
            return _services.Read(id);
        }

        public List<Vacancy> ListAllVacancy()
        {
            return _services.ReadAll();
        }

        public bool UpdateVacancy(Vacancy vac)
        {
            return _services.Update(vac);
        }


    }
}
