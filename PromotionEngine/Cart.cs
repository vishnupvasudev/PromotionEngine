using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using static PromotionEngine.Data.Enum;

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
                double OfferPrice = 0;
                Promotion promObj = promotions != null ? promotions.Where(x => x.SKUs.Contains(crtItm.SKU)).FirstOrDefault() : null;
                if (promObj != null)
                {
                    switch (promObj.PromotionType)
                    {
                        case PromotionType.NItemsPromo:
                            OfferPrice = CalculateNItemOfferPrice(crtItm.Quantity, crtItm.UnitPrice, promObj);
                            break;
                        default:
                            OfferPrice = crtItm.Quantity * crtItm.UnitPrice;
                            break;
                    }
                }else
                {
                    OfferPrice = crtItm.Quantity * crtItm.UnitPrice;
                }

                subTotal = subTotal + OfferPrice;
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
