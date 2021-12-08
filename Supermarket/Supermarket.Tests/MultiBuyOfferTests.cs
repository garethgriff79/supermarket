using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Tests
{
    [TestClass]
    public class MultiBuyOfferTests
    {
        [TestMethod]
        public void MultiBuyOfferSingleSetReturnsValue()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                }
            };
            
            var offer = new MultiBuyOffer("A99", 3, 1.3M);

            var offerValue = offer.Apply(items);

            Assert.AreEqual(1.3M, offerValue);
        }

        [TestMethod]
        public void MultiBuyOfferDoubleSetReturnsDoubleValue()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                }
            };

            var offer = new MultiBuyOffer("A99", 3, 1.3M);

            var offerValue = offer.Apply(items);

            Assert.AreEqual(2.6M, offerValue);
            Assert.AreEqual(6, items.Count(i => i.OfferApplied));
        }

        [TestMethod]
        public void MultiBuyOfferSingleSetWithExcessReturnsSingleValue()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                },
                new Item
                {
                    Sku = "A99",
                    UnitPrice = 0.5M
                }
            };

            var offer = new MultiBuyOffer("A99", 3, 1.3M);

            var offerValue = offer.Apply(items);

            Assert.AreEqual(1.3M, offerValue);
            Assert.AreEqual(3, items.Count(i => i.OfferApplied));
        }
    }
}
