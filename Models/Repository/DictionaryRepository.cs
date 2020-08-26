using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private FonNatureDbContext _db = null;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public DictionaryRepository()
        {
            _db = new FonNatureDbContext();
        }

        public List<Dictionary> GetDictionaries()
        {
            try
            {
                var dictionaries = _db.Dictionaries;
                if(dictionaries == null)
                {
                    log.Error($"{nameof(GetDictionaries)} result is null");
                    return new List<Dictionary>();
                }

                log.Info($"{nameof(GetDictionaries)} result is {dictionaries}");

                return dictionaries.ToList();
            }
            catch(Exception ex)
            {
                log.Error($"Error at {nameof(GetDictionaries)}: {ex.Message}");
                return new List<Dictionary>();
            }
        }

        public List<Dictionary> SearchDictionary(string searchString)
        {
            try
            {
                var dictionaries = _db.Dictionaries.Where(x=> x.Key.ToLower().Contains(searchString.ToLower()) || x.Value.ToLower().Contains(searchString.ToLower()));
                if (dictionaries == null)
                {
                    log.Error($"{nameof(SearchDictionary)} result is null");
                    return new List<Dictionary>();
                }

                log.Info($"{nameof(SearchDictionary)} result is {dictionaries}");

                return dictionaries.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(SearchDictionary)}: {ex.Message}");
                return new List<Dictionary>();
            }
        }

        public Dictionary GetDictionary(long id)
        {
            try
            {
                var dictionary = _db.Dictionaries.Find(id);
                if (dictionary == null)
                {
                    log.Error($"{nameof(GetDictionary)} result is null or don't have item");
                    return null;
                }

                log.Info($"{nameof(GetDictionary)} result is {dictionary}");

                return dictionary;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetDictionary)}: {ex.Message}");
                return null;
            }
        }

        public Dictionary AddDictionary(Dictionary dictionary)
        {
            try
            {
                var addedDictionary = _db.Dictionaries.Add(dictionary);
                _db.SaveChanges();

                if (addedDictionary == null)
                {
                    log.Error($"{nameof(AddDictionary)} return null");
                    return addedDictionary;
                }

                log.Info($"{nameof(AddDictionary)} result is {addedDictionary}");

                return addedDictionary;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(AddDictionary)}: {ex.Message}");
                return null;
            }
        }

        public long EditDictionary(Dictionary dictionary)
        {
            try
            {
                var updateDictionary = _db.Dictionaries.Find(dictionary.Id);
                if (updateDictionary == null)
                {
                    log.Error($"{nameof(EditDictionary)} cannot find dictionary with id {dictionary.Id}");
                    return 0;
                }

                updateDictionary.Value = dictionary.Value;
                _db.SaveChanges();

                log.Info($"{nameof(EditDictionary)} success with Key : {dictionary.Key}, Value: {dictionary.Value}");

                return updateDictionary.Id;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(EditDictionary)}: {ex.Message}");
                return 0;
            }
        }

        public bool RemoveDictionary(long id)
        {
            try
            {
                var removeDictionary = _db.Dictionaries.Find(id);
                if (removeDictionary == null)
                {
                    log.Error($"{nameof(RemoveDictionary)} cannot find dictionary with id {id}");
                    return false;
                }

                _db.Dictionaries.Remove(removeDictionary);
                _db.SaveChanges();

                log.Info($"{nameof(RemoveDictionary)} success with id : {removeDictionary.Id}");

                return true;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(RemoveDictionary)}: {ex.Message}");
                return false;
            }
        }

        public string GetDictionaryByKey(string key)
        {
            try
            {
                var dictionary = _db.Dictionaries.SingleOrDefault(x=>x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
                if (dictionary == null)
                {
                    log.Error($"{nameof(GetDictionaryByKey)} cannot find dictionary with key {key}");
                    return string.Empty;
                }

                log.Info($"{nameof(GetDictionaryByKey)} success with id : {key}");

                return dictionary.Value;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetDictionaryByKey)}: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
