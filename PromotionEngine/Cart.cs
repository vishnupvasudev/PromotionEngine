using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Cart : ICart
    {
        public double GetOrderTotal(List<CartItem> cartItems, List<Item> items)
        {
            double subTotal = 0;

            var cartItemDet = from item in items
                              join cart in cartItems on item.SKU equals cart.SKU
                              select new { SKU = item.SKU, UnitPrice = item.UnitPrice, Quantity = cart.Quantity };

            foreach (var crtItm in cartItemDet)
            {
                subTotal = subTotal + (crtItm.Quantity * crtItm.UnitPrice);
            }

            return subTotal;
        }
    }
}
