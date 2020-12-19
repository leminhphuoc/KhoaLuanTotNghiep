using log4net;
using Models.Entity;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class CouponCodeRepository : ICouponCodeRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CouponCodeRepository()
        {
            _db = new FonNatureDbContext();
        }

        public List<CouponCode> GetCouponCodes()
        {
            try
            {
                return _db.CouponCodes.ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Coupon Codes {nameof(CouponCodeRepository)}: {e.Message}");
                return new List<CouponCode>();
            }
        }

        public CouponCode GetCouponCode(string code)
        {
            try
            {
                return _db.CouponCodes.Find(code);
            }
            catch (Exception e)
            {
                log.Error($"Error at Get CouponCode function from {nameof(BenefitRepository)}: {e.Message}");
                return null;
            }
        }

        public ResultModel<string> AddCouponCode(CouponCode couponCode)
        {
            try
            {
                var resultModel = new ResultModel<string>();
                if (couponCode == null)
                {
                    log.Warn($"Null Couponcode at AddCouponCode in {nameof(CouponCodeRepository)}");
                    resultModel = new ResultModel<string>()
                    {
                        Value = string.Empty,
                        IsError = true,
                        ErrorMessage = "Null value for CouponCode"
                    };
                    return resultModel;
                }

                var isExist = _db.CouponCodes.Any(x => x.Code.Equals(couponCode.Code));
                if (isExist)
                {
                    log.Warn($"Duplicate Code at AddCouponCode in {nameof(CouponCodeRepository)}");
                    resultModel = new ResultModel<string>()
                    {
                        Value = string.Empty,
                        IsError = true,
                        ErrorMessage = "Code is exist! Please try again with another value for code"
                    };
                    return resultModel;
                }

                var itemAdded = _db.CouponCodes.Add(couponCode);
                Db.SaveChanges();

                resultModel = new ResultModel<string>()
                {
                    Value = itemAdded.Code,
                    IsError = false
                };

                return resultModel;
            }
            catch (Exception e)
            {
                log.Error($"Error at AddCouponCode function from {nameof(BenefitRepository)}: {e.Message}");
                var resultModel = new ResultModel<string>()
                {
                    Value = string.Empty,
                    IsError = true,
                    ErrorMessage = e.Message
                };
                return resultModel;
            }
        }

        public ResultModel<string> UpdateCouponCode(CouponCode couponCode)
        {
            try
            {
                var result = new ResultModel<string>();
                if(couponCode == null)
                {
                    log.Warn($"Coupon code = null in UpdateCouponCode {nameof(CouponCodeRepository)}");
                    result.IsError = true;
                    result.ErrorMessage = "Null value for coupon Code";
                    return result;
                }

                var couponCodeUpdated = _db.CouponCodes.Find(couponCode.Code);
                if(couponCodeUpdated == null)
                {
                    log.Warn($"Cannot find id of counpon - {couponCode.Code} in UpdateCouponCode {nameof(CouponCodeRepository)}");
                    result.IsError = true;
                    result.ErrorMessage = "Couldn't find coupon code";
                    return result;
                }


                couponCodeUpdated.ProductId = couponCode.ProductId;
                couponCodeUpdated.Description = couponCode.Description;
                couponCodeUpdated.DisplayName = couponCode.DisplayName;
                couponCodeUpdated.DiscountValue = couponCode.DiscountValue;
                couponCodeUpdated.Quantity = couponCode.Quantity;
                Db.SaveChanges();

                result.IsError = false;
                result.Value = couponCodeUpdated.Code;
                return result;
            }
            catch (Exception e)
            {
                log.Error($"Error at edit function from {nameof(CouponCodeRepository)}: {e.Message}");
                var result = new ResultModel<string>()
                {
                    Value = string.Empty,
                    IsError = true,
                    ErrorMessage = e.Message
                };
                return result;
            }
        }

        public bool DeleteCouponCode(string code)
        {
            try
            {
                var couponCode = _db.CouponCodes.Find(code);
                if(couponCode == null)
                {
                    log.Warn($"Null Couponcode at DeleteCouponCode in {nameof(CouponCodeRepository)}");
                    return false;
                }
                Db.CouponCodes.Remove(couponCode);
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at delete function {nameof(CouponCodeRepository)}: {e.Message}");
                return false;
            }
        }

        public List<CouponCode> GetCouponCodesByCode(string code)
        {
            try
            {
                return _db.CouponCodes.Where(x=>x.Code.ToLower().Contains(code.ToLower())).ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Coupon Codes By Name {nameof(CouponCodeRepository)}: {e.Message}");
                return new List<CouponCode>();
            }
        }

        public int ReduceQuantity(string code)
        {
            try
            {
                var couponCodeUpdated = _db.CouponCodes.Find(code);
                if(couponCodeUpdated == null)
                {
                    log.Error($"Error at ReduceQuantity from {nameof(CouponCodeRepository)}!");
                    return -1;
                }

                if(couponCodeUpdated.Quantity == 0)
                {
                    log.Warn($"Out of stock! {nameof(CouponCodeRepository)}!");
                    return -1;
                }

                couponCodeUpdated.Quantity = couponCodeUpdated.Quantity - 1;
                Db.SaveChanges();

                return couponCodeUpdated.Quantity;
            }
            catch (Exception e)
            {
                log.Error($"Error at edit function from {nameof(CouponCodeRepository)}: {e.Message}");
                return -1;
            }
        }
    }
}
