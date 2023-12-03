using _1.Entity_Layer;
using _2.Data_Layer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data_Layer.Services
{
    public class ApplicantServices : IApplicant
    {
        private AppDbContext _appDbContext;
        private Applicant appl;
        private List<Applicant> applList;

        public ApplicantServices()
        {
            _appDbContext = new AppDbContext();
        }
        public bool Create(Applicant newAppl)
        {
            try
            {
                _appDbContext.Applicants.Add(newAppl);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                appl = _appDbContext.Applicants.Find(id);
                _appDbContext.Applicants.Remove(appl);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Applicant Read(int id)
        {
            appl = _appDbContext.Applicants.Find(id);
            return appl;
        }

        public List<Applicant> ReadAll()
        {
            applList = _appDbContext.Applicants.ToList();
            return applList;
        }

        public bool Update(Applicant updAppl)
        {
            appl = _appDbContext.Applicants.Find(appl);

            if (appl != null)
            {
                appl.Status = updAppl.Status;
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
