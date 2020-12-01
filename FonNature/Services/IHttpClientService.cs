using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services
{
    public interface IHttpClientService
    {
        T Post<T>(string url, object body);
        T Get<T>(string url, object body = null);
        T Put<T>(string url, object body);
    }
}
