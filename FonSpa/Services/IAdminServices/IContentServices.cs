using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services.IServices
{
    public interface IContentServices
    {
        List<Content> ListAllByName(string searchString);
        List<ContentCategory> GetContentCategory();
        long AddContent(Content content);
        Content GetDetail(long id);
        bool EditContent(Content content);
        bool? ChangeStatus(int id);
        bool Delete(int id);
    }
}
