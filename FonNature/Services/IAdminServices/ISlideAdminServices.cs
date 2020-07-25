using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IServices
{
    public interface ISlideAdminServices
    {
        long AddSlide(Slide slide);
        bool Delete(int id);
        Slide GetDetail(int id);
        bool Edit(Slide slide);
        bool? ChangeStatus(int id);
        List<Slide> GetListSlide();
    }
}