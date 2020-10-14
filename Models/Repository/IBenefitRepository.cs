using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IBenefitRepository
    {
        long Add(Benefit benefit);
        bool Delete(long id);
        bool Edit(Benefit benefit);
        Benefit GetDetail(long id);
        List<Benefit> GetBenefits();
    }
}
