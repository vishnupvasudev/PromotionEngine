using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Data;
using System.Collections.Generic;
using static PromotionEngine.Data.Enum;

namespace PromotionEngine.UnitTest
{
    [TestClass]
    public class CartTest
    {
        private readonly ICart _cart;

        public CartTest()
        {
            this._cart = new Cart();
        }

        [TestMethod]
        public void GetOrderTotal_TotalWithoutPromotions_ReturnTotalPrice()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem() { SKU = "A", Quantity = 2 });
            cartItems.Add(new CartItem() { SKU = "B", Quantity = 1 });
            cartItems.Add(new CartItem() { SKU = "C", Quantity = 2 });
            cartItems.Add(new CartItem() { SKU = "D", Quantity = 1 });

            List<Item> allSKUs = this.GetAllSKUs();
            int expected = (2 * 50) + (1 * 30) + (2 * 20) + (1 * 15);

            double total = this._cart.GetOrderTotal(cartItems, allSKUs);

            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void CalculateNItemOfferPrice_ApplyNItemPromotion_ReturnOfferPrice()
        {
            int itemQuantity = 5;
            double unitPrice = 50;
            Promotion prom = new Promotion() { Quantity = 3, PromotionType = PromotionType.NItemsPromo, OfferPrice = 130 };
            int expectedResult = 130 + (2 * 50);

            double offerPrice = this._cart.CalculateNItemOfferPrice(itemQuantity, unitPrice, prom);

            Assert.AreEqual(expectedResult, offerPrice);
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
