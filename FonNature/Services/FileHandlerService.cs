using log4net;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace FonNature.Services
{
    public class FileHandlerService : IFileHandlerService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public T ReadJsonFile<T>(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath(path)))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch(Exception ex)
            {
                log.Error($"Error in FileHandlerService.ReadJsonFile : {ex.Message}");
                return default(T);
            }
            
        }
    }
}