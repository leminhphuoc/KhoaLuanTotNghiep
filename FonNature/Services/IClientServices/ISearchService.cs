using Models.Model;
using System.Collections.Generic;

namespace FonNature.Services.IClientServices
{
    public interface ISearchService
    {
        List<SearchItem> GetResults(string searchString);
    }
}
