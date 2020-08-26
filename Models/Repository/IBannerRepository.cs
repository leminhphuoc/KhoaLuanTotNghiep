using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IBannerRepository
    {
        Banner GetDetail(long id);
        List<Banner> GetList();
        long Add(Banner banner);
        bool Edit(Banner banner);
        bool Delete(long id);
    }
}
