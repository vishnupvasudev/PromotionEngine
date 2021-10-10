﻿using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Cart : ICart
    {
        public double GetOrderTotal(List<CartItem> cartItems, List<Item> items, List<Promotion> promotions = null)
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

        public double CalculateNItemOfferPrice(int itemQuantity, double UnitPrice, Promotion promObj)
        {
            double xOff = itemQuantity / promObj.Quantity;
            int remaining = itemQuantity % promObj.Quantity;
            return (Math.Floor(xOff) * promObj.OfferPrice) + (remaining * UnitPrice);
        }

        public bool CheckCombinationExists(List<string> compareList, List<string> PromotionSKUs)
        {
            if (compareList != null && PromotionSKUs != null)
            {
                return PromotionSKUs.Except(compareList).Count() == 0;
            }
            return false;
        }
    }
}
