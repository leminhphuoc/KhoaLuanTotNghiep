using FonNature.Enum;
using FonNature.Services.IClientServices;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services.ClientServices
{
    public class BlogServices : IBlogServices
    {
        private readonly ContentAdminRepository _contentAdminRepository;
        private readonly ContentCategoryAdminRepository _contentCategoryAdminRepository;
        private readonly SEORepository _seoRepository;
        private readonly BannerRepository _bannerRepository;
        public BlogServices()
        {
            _contentAdminRepository = ContentAdminRepository.getInstance();
            _contentCategoryAdminRepository = ContentCategoryAdminRepository.getInstance();
            _seoRepository = SEORepository.getInstance();
            _bannerRepository = BannerRepository.getInstance();
        }
        public SEO GetSeo()
        {
            return _seoRepository.GetSEO(3);
        }

        public List<Content> ListAll(string searchString)
        {
            if(searchString != null)
            {
                return _contentAdminRepository.ListSearchContent(searchString).Where(x => x.status == true).OrderBy(x => x.createdDate).ToList();
            }
            return _contentAdminRepository.GetListContent().Where(x=>x.status == true).OrderBy(x=>x.createdDate).ToList();
        }

        public List<Content> ListAllByCategory(string searchString,int idCategory)
        {
            if (searchString != null)
            {
                return _contentAdminRepository.ListSearchContent(searchString).Where(x => x.categoryID == idCategory && x.status == true).OrderBy(x => x.createdDate).ToList();
            }
            return _contentAdminRepository.GetListContent().Where(x => x.categoryID == idCategory && x.status == true).OrderBy(x=>x.createdDate).ToList();
        }

        public List<ContentCategory> ListContentCategory()
        {
            return _contentCategoryAdminRepository.GetListContentCategory().Where(x => x.status == true).OrderBy(x => x.displayOrder).ToList();
        }

        public List<Content> ListRecentBlog()
        {
            return _contentAdminRepository.GetListContent().Where(x => x.status == true).OrderBy(x => x.createdDate).Take(3).ToList();
        }
        public Content GetDetail(long id)
        {
            if (id == 0) return null;
            return _contentAdminRepository.GetDetail(id);
        }

        public Banner GetBanner()
        {
            return _bannerRepository.GetList().SingleOrDefault(x => x.Location == (int)BannerLocation.Blog);
        }

    }
}