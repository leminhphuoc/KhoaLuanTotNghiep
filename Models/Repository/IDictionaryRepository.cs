using System.Collections.Generic;
using Models.Entity;

namespace Models.Repository
{
    public interface IDictionaryRepository
    {
        List<Dictionary> GetDictionaries();
        Dictionary GetDictionary(long id);
        Dictionary AddDictionary(Dictionary dictionary);
        long EditDictionary(Dictionary dictionary);
        bool RemoveDictionary(Dictionary dictionary);
        List<Dictionary> SearchDictionary(string searchString);
    }
}
