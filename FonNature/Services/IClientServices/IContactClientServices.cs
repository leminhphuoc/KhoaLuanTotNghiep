using Models.Entity;

namespace FonNature.Services.IServices
{
    public interface IContactClientServices
    {
        Contact GetContact();
        SEO GetSeo();
        Banner GetBanner();
    }
}
