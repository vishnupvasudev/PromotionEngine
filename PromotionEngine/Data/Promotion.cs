#region Included namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PromotionEngine.Data.Enum;
#endregion Included namespaces

namespace PromotionEngine.Data
{
    public class Promotion
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// SKUs
        /// </summary>
        public List<string> SKUs { get; set; }

        /// <summary>
        /// PromotionType
        /// </summary>
        public PromotionType PromotionType { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// OfferPrice
        /// </summary>
        public double OfferPrice { get; set; }
    }
}
