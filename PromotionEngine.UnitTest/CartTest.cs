#region IncludedNamespaces
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Data;
using System.Collections.Generic;
using static PromotionEngine.Data.Enum;
#endregion IncludedNamespaces

namespace PromotionEngine.UnitTest
{
    [TestClass]
    public class CartTest
    {
        #region Private member

        /// <summary>
        /// _cart
        /// </summary>
        private readonly ICart _cart;

        #endregion Private member

        #region CartTest
        /// <summary>
        /// Constructor
        /// </summary>
        public CartTest()
        {
            this._cart = new Cart();
        }
        #endregion CartTest

        #region GetOrderTotal_TotalWithoutPromotions_ReturnTotalPrice
        /// <summary>
        /// GetOrderTotal_TotalWithoutPromotions_ReturnTotalPrice
        /// </summary>
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
        #endregion GetOrderTotal_TotalWithoutPromotions_ReturnTotalPrice

        #region CalculateNItemOfferPrice_ApplyNItemPromotion_ReturnOfferPrice
        /// <summary>
        /// CalculateNItemOfferPrice_ApplyNItemPromotion_ReturnOfferPrice
        /// </summary>
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
        #endregion CalculateNItemOfferPrice_ApplyNItemPromotion_ReturnOfferPrice

        #region CheckCombinationExists_CombinationExist_ReturnTrue
        /// <summary>
        /// CheckCombinationExists_CombinationExist_ReturnTrue
        /// </summary>
        [TestMethod]
        public void CheckCombinationExists_CombinationExist_ReturnTrue()
        {
            List<string> compareList = new List<string> { "A", "B", "C" };
            List<string> PromotionSKUs = new List<string> { "A", "B" };

            bool isContains = this._cart.CheckCombinationExists(compareList, PromotionSKUs);

            Assert.IsTrue(isContains);
        }
        #endregion CheckCombinationExists_CombinationExist_ReturnTrue

        #region CheckCombinationExists_CombinationNotExist_ReturnFalse
        /// <summary>
        /// CheckCombinationExists_CombinationNotExist_ReturnFalse
        /// </summary>
        [TestMethod]
        public void CheckCombinationExists_CombinationNotExist_ReturnFalse()
        {
            List<string> compareList = new List<string> { "A", "B", "C" };
            List<string> PromotionSKUs = new List<string> { "C", "D" };

            bool isContains = this._cart.CheckCombinationExists(compareList, PromotionSKUs);

            Assert.IsFalse(isContains);
        }
        #endregion CheckCombinationExists_CombinationNotExist_ReturnFalse

        #region GetOrderTotal_TotalWithnItemPromotions_ReturnTotalPrice
        /// <summary>
        /// GetOrderTotal_TotalWithnItemPromotions_ReturnTotalPrice
        /// </summary>
        [TestMethod]
        public void GetOrderTotal_TotalWithnItemPromotions_ReturnTotalPrice()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem() { SKU = "A", Quantity = 5 });
            cartItems.Add(new CartItem() { SKU = "B", Quantity = 5 });
            cartItems.Add(new CartItem() { SKU = "C", Quantity = 1 });

            List<Promotion> promos = this.GetActivePromotions();
            List<Item> allSKUs = this.GetAllSKUs();
            int expectedResult = (130 + 2 * 50) + (2 * 45 + 30) + 20;

            double total = this._cart.GetOrderTotal(cartItems, allSKUs, promos);

            Assert.AreEqual(expectedResult, total);
        }
        #endregion GetOrderTotal_TotalWithnItemPromotions_ReturnTotalPrice

        #region GetOrderTotal_TotalWithComboItemPromotions_ReturnTotalPrice
        /// <summary>
        /// GetOrderTotal_TotalWithComboItemPromotions_ReturnTotalPrice
        /// </summary>
        [TestMethod]
        public void GetOrderTotal_TotalWithComboItemPromotions_ReturnTotalPrice()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem() { SKU = "A", Quantity = 3 });
            cartItems.Add(new CartItem() { SKU = "B", Quantity = 5 });
            cartItems.Add(new CartItem() { SKU = "C", Quantity = 1 });
            cartItems.Add(new CartItem() { SKU = "D", Quantity = 1 });

            List<Promotion> promos = this.GetActivePromotions();
            List<Item> allSKUs = this.GetAllSKUs();
            int expectedResult = (130) + (2 * 45 + 30) + 30;

            double total = this._cart.GetOrderTotal(cartItems, allSKUs, promos);

            Assert.AreEqual(expectedResult, total);
        }
        #endregion GetOrderTotal_TotalWithComboItemPromotions_ReturnTotalPrice

        #region GetAllSKUs
        /// <summary>
        /// GetAllSKUs
        /// </summary>
        /// <returns></returns>
        private List<Item> GetAllSKUs()
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
        private List<Promotion> GetActivePromotions()
        {
            List<Promotion> promos = new List<Promotion>();
            promos.Add(new Promotion() { 
                Name = "3 of A's for 130", 
                SKUs = new List<string> { "A" }, 
                Quantity = 3, 
                PromotionType = PromotionType.NItemsPromo, 
                OfferPrice = 130 }
            );
            promos.Add(new Promotion() { 
                Name = "2 of B's for 45", 
                SKUs = new List<string> { "B" }, 
                Quantity = 2, 
                PromotionType = PromotionType.NItemsPromo, 
                OfferPrice = 45 }
            );
            promos.Add(new Promotion() { 
                Name = "C & D for 30", 
                SKUs = new List<string> { "C", "D" }, 
                PromotionType = PromotionType.ComboPromo, 
                OfferPrice = 30 }
            );
            return promos;
        }
        #endregion GetActivePromotions
    }
}
