using _1.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data_Layer.Repo
{
    public interface IApplicant
    {
        List<Applicant> ReadAll();
        Applicant Read(int id);
        bool Create(Applicant newAppl);
        bool Update(Applicant updAppl);
        bool Delete(int id);
    }
}
