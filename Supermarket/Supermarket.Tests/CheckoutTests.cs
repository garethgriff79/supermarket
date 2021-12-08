using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Supermarket.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void ScanItem_AddSingle_ReturnsSingleItem()
        {
            var checkout = new Checkout();

            var item = new Item
            {
                Sku = "test1",
                UnitPrice = 0.5M
            };

            checkout.ScanItem(item);

            Assert.AreEqual(1, checkout.GetScannedItems().Count);
            Assert.AreEqual(item, checkout.GetScannedItems().First());
        }

        [TestMethod]
        public void ScanItem_AddMultiple_ReturnsMultipleItems()
        {
            var checkout = new Checkout();

            var item1 = new Item
            {
                Sku = "test1",
                UnitPrice = 0.5M
            };

            var item2 = new Item
            {
                Sku = "test2",
                UnitPrice = 0.75M
            };

            var item3 = new Item
            {
                Sku = "test3",
                UnitPrice = 0.99M
            };

            checkout.ScanItem(item1);
            checkout.ScanItem(item2);
            checkout.ScanItem(item3);

            Assert.AreEqual(3, checkout.GetScannedItems().Count);
            Assert.IsTrue(checkout.GetScannedItems().Any(x => x == item1));
            Assert.IsTrue(checkout.GetScannedItems().Any(x => x == item2));
            Assert.IsTrue(checkout.GetScannedItems().Any(x => x == item3));
        }

        [TestMethod]
        public void GetTotalPrice_SingleItem_ReturnsSinglePrice()
        {
            var checkout = new Checkout();

            var item = new Item
            {
                Sku = "test1",
                UnitPrice = 0.5M
            };

            checkout.ScanItem(item);

            var totalPrice = checkout.GetTotalPrice();

            Assert.AreEqual(0.5M, totalPrice);
        }

        [TestMethod]
        public void GetTotalPrice_MultipleItems_ReturnsSumItemPrice()
        {
            var checkout = new Checkout();

            var item1 = new Item
            {
                Sku = "test1",
                UnitPrice = 0.5M
            };

            var item2 = new Item
            {
                Sku = "test2",
                UnitPrice = 0.75M
            };

            var item3 = new Item
            {
                Sku = "test3",
                UnitPrice = 0.99M
            };

            checkout.ScanItem(item1);
            checkout.ScanItem(item2);
            checkout.ScanItem(item3);

            var totalPrice = checkout.GetTotalPrice();

            Assert.AreEqual(2.24M, totalPrice);
        }
    }
}
