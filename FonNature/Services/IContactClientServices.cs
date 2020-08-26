using Models.Entity;

namespace FonNature.Services
{
    public interface IContactClientServices
    {
        Contact GetContact();
        SEO GetSeo();
        Banner GetBanner();
    }
}
