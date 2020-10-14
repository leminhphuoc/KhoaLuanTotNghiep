using FonNature.Enum;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly IContentAdminRepository _contentAdminRepository;
        private readonly IContentCategoryAdminRepository _contentCategoryAdminRepository;
        private readonly ISEORepository _seoRepository;
        private readonly IBannerRepository _bannerRepository;
        public BlogServices(IContentAdminRepository contentAdminRepository, IContentCategoryAdminRepository contentCategoryAdminRepository,
            ISEORepository seoRepository, IBannerRepository bannerRepository)
        {
            _contentAdminRepository = contentAdminRepository;
            _contentCategoryAdminRepository = contentCategoryAdminRepository;
            _seoRepository = seoRepository;
            _bannerRepository = bannerRepository;
        }
        public SEO GetSeo()
        {
            return _seoRepository.GetSEO(3);
        }

        public List<Content> ListAll(string searchString)
        {
            if (searchString != null)
            {
                return _contentAdminRepository.ListSearchContent(searchString).Where(x => x.status == true).OrderBy(x => x.createdDate).ToList();
            }
            return _contentAdminRepository.GetListContent().Where(x => x.status == true).OrderBy(x => x.createdDate).ToList();
        }

        public List<Content> ListAllByCategory(string searchString, int idCategory)
        {
            if (searchString != null)
            {
                return _contentAdminRepository.ListSearchContent(searchString).Where(x => x.categoryID == idCategory && x.status == true).OrderBy(x => x.createdDate).ToList();
            }
            return _contentAdminRepository.GetListContent().Where(x => x.categoryID == idCategory && x.status == true).OrderBy(x => x.createdDate).ToList();
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