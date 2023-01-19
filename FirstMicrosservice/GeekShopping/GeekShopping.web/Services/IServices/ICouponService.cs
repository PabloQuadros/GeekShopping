using GeekShopping.web.Models;

namespace GeekShopping.web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
       
    }
}
