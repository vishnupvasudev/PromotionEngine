#region IncludedNamespaces
using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using static PromotionEngine.Data.Enum;
#endregion IncludedNamespaces

namespace PromotionEngine
{
    #region Cart
    /// <summary>
    /// Cart
    /// </summary>
    public class Cart : ICart
    {
        #region GetOrderTotal
        /// <summary>
        /// GetOrderTotal
        /// </summary>
        /// <param name="cartItems"></param>
        /// <param name="items"></param>
        /// <param name="promotions"></param>
        /// <returns></returns>
        public double GetOrderTotal(List<CartItem> cartItems, List<Item> items, List<Promotion> promotions = null)
        {
            double subTotal = 0;

            var cartItemDet = from item in items
                              join cart in cartItems on item.SKU equals cart.SKU
                              select new { SKU = item.SKU, UnitPrice = item.UnitPrice, Quantity = cart.Quantity };

            List<string> compareList = new List<string>();
            foreach (var crtItm in cartItemDet)
            {
                double OfferPrice = 0;
                double actualPrice = crtItm.Quantity * crtItm.UnitPrice;
                compareList.Add(crtItm.SKU);
                Promotion promObj = promotions != null ? promotions.Where(x => x.SKUs.Contains(crtItm.SKU)).FirstOrDefault() : null;
                if (promObj != null)
                {
                    switch (promObj.PromotionType)
                    {
                        case PromotionType.NItemsPromo:
                            OfferPrice = CalculateNItemOfferPrice(crtItm.Quantity, crtItm.UnitPrice, promObj);
                            break;
                        case PromotionType.ComboPromo:
                            List<string> cartSKUs = cartItems.Select(x => x.SKU).ToList();
                            if (!CheckCombinationExists(cartSKUs, promObj.SKUs))
                            {
                                OfferPrice = actualPrice;
                            }
                            else if (CheckCombinationExists(compareList, promObj.SKUs))
                            {
                                OfferPrice = promObj.OfferPrice;
                            }
                            break;
                        case PromotionType.PercentagePromo:
                            ////New methods for calculating the offer price by percentage promotion type goes here.
                            break;
                        default:
                            OfferPrice = actualPrice;
                            break;
                    }
                }
                else
                {
                    OfferPrice = actualPrice;
                }

                subTotal = subTotal + OfferPrice;
            }

            return subTotal;
        }
        #endregion GetOrderTotal

        #region CalculateNItemOfferPrice
        /// <summary>
        /// CalculateNItemOfferPrice
        /// </summary>
        /// <param name="itemQuantity"></param>
        /// <param name="UnitPrice"></param>
        /// <param name="promObj"></param>
        /// <returns></returns>
        public double CalculateNItemOfferPrice(int itemQuantity, double UnitPrice, Promotion promObj)
        {
            double xOff = itemQuantity / promObj.Quantity;
            int remaining = itemQuantity % promObj.Quantity;
            return (Math.Floor(xOff) * promObj.OfferPrice) + (remaining * UnitPrice);
        }
        #endregion CalculateNItemOfferPrice

        #region CheckCombinationExists
        /// <summary>
        /// CheckCombinationExists
        /// </summary>
        /// <param name="compareList"></param>
        /// <param name="PromotionSKUs"></param>
        /// <returns></returns>
        public bool CheckCombinationExists(List<string> compareList, List<string> PromotionSKUs)
        {
            if (compareList != null && PromotionSKUs != null)
            {
                return PromotionSKUs.Except(compareList).Count() == 0;
            }
            return false;
        }
        #endregion CheckCombinationExists
    }
    #endregion Cart
}
