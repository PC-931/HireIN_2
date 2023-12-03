using _1.Entity_Layer;
using _2.Data_Layer.Repo;
using System.Collections.Generic;
using System.Linq;

namespace _2.Data_Layer.Services
{
    public class VacancyServices : IVacancy
    {
        private AppDbContext _appDbContext;
        private Vacancy vac;
        private List<Vacancy> vacancyList;

        public VacancyServices()
        {
            _appDbContext = new AppDbContext();
            vac = new Vacancy();
        }

        public bool Create(Vacancy newVac)
        {
            try
            {
                _appDbContext.Vacancies.Add(newVac);
                _appDbContext.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                vac = _appDbContext.Vacancies.Find(id);
                _appDbContext.Vacancies.Remove(vac);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Vacancy Read(int id)
        {
            vac = _appDbContext.Vacancies.Find(id);
            return vac;
        }

        public List<Vacancy> ReadAll()
        {
            vacancyList = _appDbContext.Vacancies.ToList();
            return vacancyList;
        }

        public bool Update(Vacancy updVac)
        {
            vac = _appDbContext.Vacancies.Find(updVac.VacancyId);

            if (vac != null)
            {
                vac.JobTitle = updVac.JobTitle;
                vac.JobDescription = updVac.JobDescription;
                vac.JobLocation = updVac.JobLocation;
                vac.Salary = updVac.Salary;
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
