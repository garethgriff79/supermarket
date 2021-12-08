using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    public class MultiBuyOffer
    {
        private readonly string _sku;
        private readonly int _quantity;
        private readonly decimal _offerPrice;

        public MultiBuyOffer(string sku, int quantity, decimal offerPrice)
        {
            _sku = sku;
            _quantity = quantity;
            _offerPrice = offerPrice;
        }

        public decimal Apply(IEnumerable<Item> items)
        {
            var availableItems = items.ToList();
            decimal offerTotal = 0;

            while (availableItems.Any())
            {
                if (availableItems.Count(p => p.Sku == _sku) >= _quantity)
                {
                    var numberItemsAppliedTo = 0;

                    foreach (var appliedItem in items.Where(i => i.Sku == _sku && !i.OfferApplied))
                    {
                        appliedItem.OfferApplied = true;
                        availableItems.Remove(availableItems.First(i => i.Sku == _sku));

                        numberItemsAppliedTo++;

                        if (numberItemsAppliedTo == _quantity)
                        {
                            break;
                        }
                    }

                    offerTotal += _offerPrice;
                }
                else
                {
                    // no more products for the SKU and quantity required left so escape the while loop
                    availableItems = new List<Item>();
                }
            }

            return offerTotal;
        }
    }
}
