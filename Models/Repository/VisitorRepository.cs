using Models.Entity;

namespace Models.Repository
{
    public class VisitorRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static VisitorRepository instance = new VisitorRepository();

        private VisitorRepository()
        {
            _db = new FonNatureDbContext();
        }

        public static VisitorRepository getInstance()
        {
            return instance;
        }
    }
}
