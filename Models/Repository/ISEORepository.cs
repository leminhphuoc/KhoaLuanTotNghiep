using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface ISEORepository
    {
        List<SEO> GetSEOs();
        SEO GetSEO(int typeId);
        SEO GetSEODetail(long id);
        long EditSEO(SEO seo);
    }
}
