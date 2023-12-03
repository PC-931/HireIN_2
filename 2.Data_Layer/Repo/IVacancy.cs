using _1.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data_Layer.Repo
{
    public interface IVacancy
    {
        List<Vacancy> ReadAll();
        Vacancy Read(int id);
        bool Create(Vacancy newVac);
        bool Update(Vacancy updVac);
        bool Delete(int id);
    }
}
