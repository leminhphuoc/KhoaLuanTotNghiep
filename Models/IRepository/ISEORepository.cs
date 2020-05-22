using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface ISEORepository
    {
        List<SEO> GetSEOs();
        SEO GetSEO(int typeId);
        SEO GetSEODetail(long id);
        long EditSEO(SEO seo);
    }
}
