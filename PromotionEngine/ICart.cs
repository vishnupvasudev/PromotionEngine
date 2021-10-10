#region Included namespaces
using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included namespaces

namespace PromotionEngine
{
    #region ICart
    /// <summary>
    /// ICart
    /// </summary>
    public interface ICart
    {
        /// <summary>
        /// GetOrderTotal
        /// </summary>
        /// <param name="cartItems"></param>
        /// <param name="items"></param>
        /// <param name="promotions"></param>
        /// <returns></returns>
        double GetOrderTotal(List<CartItem> cartItems, List<Item> items, List<Promotion> promotions = null);

        /// <summary>
        /// CalculateNItemOfferPrice
        /// </summary>
        /// <param name="itemQuantity"></param>
        /// <param name="UnitPrice"></param>
        /// <param name="promObj"></param>
        /// <returns></returns>
        double CalculateNItemOfferPrice(int itemQuantity, double UnitPrice, Promotion promObj);

        /// <summary>
        /// CheckCombinationExists
        /// </summary>
        /// <param name="compareList"></param>
        /// <param name="PromotionSKUs"></param>
        bool CheckCombinationExists(List<string> compareList, List<string> PromotionSKUs);
    }
    #endregion ICart
}
