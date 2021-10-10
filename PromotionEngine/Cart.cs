using PromotionEngine.Data;
using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class Cart : ICart
    {
        public double GetOrderTotal(List<CartItem> cartItems, List<Item> items)
        {
            double subTotal = 0;
            return subTotal;
        }
    }
}
