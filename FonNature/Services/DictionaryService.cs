using Models.Repository;

namespace FonNature.Services
{
    public static class DictionaryService
    {
        public static string GetDictionaryValue(string key)
        {
            var value = new DictionaryRepository().GetDictionaryByKey(key);
            if (string.IsNullOrEmpty(value)) return key;
            return value;
        }
    }
}