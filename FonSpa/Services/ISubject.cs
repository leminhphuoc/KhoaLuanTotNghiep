namespace FonNature.Services
{
    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void unregisterObserver(IObserver o);
        void notifyObservers();
    }
}
