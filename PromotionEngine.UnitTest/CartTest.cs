using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Data;
using System.Collections.Generic;
using static PromotionEngine.Data.Enum;

namespace PromotionEngine.UnitTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        #region GetAllSKUs
        /// <summary>
        /// GetAllSKUs
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllSKUs()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { SKU = "A", UnitPrice = 50 });
            items.Add(new Item() { SKU = "B", UnitPrice = 30 });
            items.Add(new Item() { SKU = "C", UnitPrice = 20 });
            items.Add(new Item() { SKU = "D", UnitPrice = 15 });

            return items;
        }
        #endregion GetAllSKUs

        #region GetActivePromotions
        /// <summary>
        /// GetActivePromotions
        /// </summary>
        /// <returns></returns>
        public List<Promotion> GetActivePromotions()
        {
            List<Promotion> promos = new List<Promotion>();
            promos.Add(new Promotion() { Name = "3 of A's for 130", SKUs = new List<string> { "A" }, Quantity = 3, PromotionType = PromotionType.NItemsPromo, OfferPrice = 130 });
            promos.Add(new Promotion() { Name = "2 of B's for 45", SKUs = new List<string> { "B" }, Quantity = 2, PromotionType = PromotionType.NItemsPromo, OfferPrice = 45 });
            promos.Add(new Promotion() { Name = "C & D for 30", SKUs = new List<string> { "C", "D" }, PromotionType = PromotionType.ComboPromo, OfferPrice = 30 });
            return promos;
        }
        #endregion GetActivePromotions
    }
}
