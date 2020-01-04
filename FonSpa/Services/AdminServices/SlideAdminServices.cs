using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace FonNature.Services.Services
{
    public class SlideAdminServices : ISlideAdminServices
    {
        private readonly ISlideAdminRepository _slideAdminRepository;
        public SlideAdminServices(ISlideAdminRepository slideAdminRepository)
        {
            _slideAdminRepository = slideAdminRepository;
        }

        public List<Slide> GetListSlide()
        {
            return _slideAdminRepository.GetListSlide();
        }

        public long AddSlide(Slide slide)
        {
            if (slide == null) return 0;
            var addSlide = _slideAdminRepository.AddSlide(slide);
            var idSlide = addSlide;
            return idSlide;
        }

        public Slide GetDetail(int id)
        {
            if (id == 0) return null;
            var slide = _slideAdminRepository.GetDetail(id);
            return slide;
        }

        public bool Edit(Slide slide)
        {
            if (slide == null) return false;
            var editSlide = _slideAdminRepository.EditSlide(slide);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _slideAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _slideAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}