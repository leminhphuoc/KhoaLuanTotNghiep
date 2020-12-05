namespace FonNature.Services
{
    public interface IFileHandlerService
    {
        T ReadJsonFile<T>(string path);
    }
}
