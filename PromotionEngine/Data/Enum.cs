#region Included namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included namespaces

namespace PromotionEngine.Data
{
    public class Enum
    {
        #region PromotionType
        /// <summary>
        /// PromotionType
        /// </summary>
        public enum PromotionType
        {
            /// <summary>
            /// FixedAmount
            /// </summary>
            NItemsPromo = 1,

            /// <summary>
            /// PercentageDiscount
            /// </summary>
            ComboPromo = 2,

            /// <summary>
            /// For more promotion types here for percentage
            /// </summary>
            PercentagePromo = 3
        }
        #endregion PromotionType
    }
}
