using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class SEORepository : ISEORepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public SEORepository()
        {
            _db = new FonNatureDbContext();

        }

        public List<SEO> GetSEOs()
        {
            return _db.SEOs.ToList();
        }
        public SEO GetSEO(int typeId)
        {
            return _db.SEOs.SingleOrDefault(x => x.TypeId.Equals(typeId));
        }

        public SEO GetSEODetail(long id)
        {
            return _db.SEOs.SingleOrDefault(x => x.Id.Equals(id));
        }

        public long EditSEO(SEO seo)
        {
            var source = _db.SEOs.SingleOrDefault(x => x.Id.Equals(seo.Id));
            source.MetaTitle = seo.MetaTitle;
            source.MetaDescription = seo.MetaDescription;
            source.MetaKeyWord = seo.MetaKeyWord;
            _db.SaveChanges();
            return source.Id;
        }

    }
}
