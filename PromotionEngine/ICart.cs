using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public interface ICart
    {
        double GetOrderTotal(List<CartItem> cartItems, List<Item> items);
        double CalculateNItemOfferPrice(int itemQuantity, double UnitPrice, Promotion promObj);
    }
}
