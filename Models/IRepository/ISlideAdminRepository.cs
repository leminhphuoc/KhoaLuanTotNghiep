using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
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

