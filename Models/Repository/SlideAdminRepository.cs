using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class SlideAdminRepository : ISlideAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public SlideAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Slide GetDetail(long id)
        {
            var slide = _db.Slides.Find(id);
            return slide;
        }

        public List<Slide> GetListSlide()
        {
            return _db.Slides.ToList();
        }

        public List<Slide> GetListTrue()
        {
            return _db.Slides.Where(x => x.status == true).OrderBy(x => x.displayOrder).ToList();
        }

        public long AddSlide(Slide slide)
        {
            slide.createdDate = DateTime.Now;
            var addSlide = _db.Slides.Add(slide);
            _db.SaveChanges();
            return addSlide.id;
        }

        public bool EditSlide(Slide slide)
        {
            var SlideEdit = _db.Slides.Where(x => x.id == slide.id).SingleOrDefault();
            SlideEdit.image = slide.image;
            SlideEdit.displayOrder = slide.displayOrder;
            SlideEdit.link = slide.link;
            SlideEdit.title = slide.title;
            SlideEdit.subtitle = slide.subtitle;
            SlideEdit.modifiedDate = DateTime.Now;
            SlideEdit.status = slide.status;
            SlideEdit.YellowTitle = slide.YellowTitle;
            SlideEdit.SlideType = slide.SlideType;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var slide = _db.Slides.Find(id);
            if (slide != null)
            {
                _db.Slides.Remove(slide);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Slides.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }
    }
}
