using System.Collections.Generic;
using FonNature.Services.IClientServices;
using Models.Model;
using Models.Repository;

namespace FonNature.Services.ClientServices
{
    public class SearchService : ISearchService
    {
        private readonly ProductAdminRepository _productAdminRepository;
        private readonly ContentAdminRepository _contentAdminRepository;
        public SearchService()
        {
            _productAdminRepository = ProductAdminRepository.getInstance();
            _contentAdminRepository = ContentAdminRepository.getInstance();
        }
        public List<SearchItem> GetResults(string searchString)
        {
            var productInSearchResult = _productAdminRepository.ListSearchProduct(searchString);
            var contentInSearchResult = _contentAdminRepository.ListSearchContent(searchString);
            var searchResults = new List<SearchItem>();
            foreach(var product in productInSearchResult)
            {
                var result = new SearchItem();
                result.Name = product.name;
                result.Description = product.description;
                result.Image = product.image;
                result.Link = "/product/Detail?id=" + product.id;
                result.Type = Models.Model.Enum.SearchItemType.Product;
                searchResults.Add(result);
            }
            foreach (var content in contentInSearchResult)
            {
                var result = new SearchItem();
                result.Name = content.name;
                result.Description = content.description;
                result.Image = content.image;
                result.Link = "/blog/Detail?id=" + content.id;
                result.Type = Models.Model.Enum.SearchItemType.Blog;
                searchResults.Add(result);
            }

            return searchResults;
        }
    }
}