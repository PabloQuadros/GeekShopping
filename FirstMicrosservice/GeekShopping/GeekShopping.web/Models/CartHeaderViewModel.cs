
namespace GeekShopping.web.Models
{

    public class CartHeaderViewModel
    {

        public long? Id { get; set; }
        public string? UserId { get; set; }
        public decimal? PurchaseAmount { get; set; }
        public string? CouponCode { get; set; }
    }
}
