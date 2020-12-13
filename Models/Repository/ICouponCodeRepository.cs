using Models.Entity;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface ICouponCodeRepository
    {
        List<CouponCode> GetCouponCodes();
        CouponCode GetCouponCode(string code);
        ResultModel<string> AddCouponCode(CouponCode couponCode);
        ResultModel<string> UpdateCouponCode(CouponCode couponCode);
        bool DeleteCouponCode(string code);
        List<CouponCode> GetCouponCodesByCode(string code);
    }
}
