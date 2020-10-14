using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class BenefitRepository : IBenefitRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BenefitRepository()
        {
            _db = new FonNatureDbContext();
        }

        public long Add(Benefit benefit)
        {
            try
            {
                var addedItem = _db.Benefits.Add(benefit);
                Db.SaveChanges();
                return addedItem.Id;
            }
            catch (Exception e)
            {
                log.Error($"Error at add function from {nameof(BenefitRepository)}: {e.Message}");
                return 0;
            }

        }

        public bool Delete(long id)
        {
            try
            {
                var benefit = _db.Benefits.Find(id);
                Db.Benefits.Remove(benefit);
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at delete function {nameof(BenefitRepository)}: {e.Message}");
                return false;
            }
        }

        public bool Edit(Benefit benefit)
        {
            try
            {
                var benefitNeedEdit = _db.Benefits.Find(benefit.Id);
                benefitNeedEdit.Name = benefit.Name;
                benefitNeedEdit.Description = benefit.Description;
                benefitNeedEdit.Image = benefit.Image;
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at edit function from {nameof(BenefitRepository)}: {e.Message}");
                return false;
            }
        }

        public Benefit GetDetail(long id)
        {
            try
            {
                var benefit = _db.Benefits.Find(id);
                return benefit;
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Benefit function from {nameof(BenefitRepository)}: {e.Message}");
                return null;
            }
        }

        public List<Benefit> GetBenefits()
        {
            try
            {
                return _db.Benefits.ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Benefits {nameof(BenefitRepository)}: {e.Message}");
                return new List<Benefit>();
            }
        }
    }
}
