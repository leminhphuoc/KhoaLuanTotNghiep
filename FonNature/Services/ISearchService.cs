using Models.Model;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface ISearchService
    {
        List<SearchItem> GetResults(string searchString);
    }
}
