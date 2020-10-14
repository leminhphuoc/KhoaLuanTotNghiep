using Models.Entity;

namespace Models.Repository
{
    public class VisitorRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public VisitorRepository()
        {
            _db = new FonNatureDbContext();

        }


    }
}
