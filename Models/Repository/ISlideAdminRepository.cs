using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface ISlideAdminRepository
    {
        Slide GetDetail(long id);
        List<Slide> GetListSlide();
        bool? ChangeStatus(long id);
        long AddSlide(Slide slide);
        bool EditSlide(Slide slide);
        bool Delete(long id);
        List<Slide> GetListTrue();
    }
}

