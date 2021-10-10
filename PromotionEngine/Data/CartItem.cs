#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace PromotionEngine.Data
{
    public class CartItem
    {
        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ActualPrice
        /// </summary>
        public double ActualPrice { get; set; }

        /// <summary>
        /// OfferPrice
        /// </summary>
        public double OfferPrice { get; set; }
    }
}
