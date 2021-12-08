using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    public class Checkout
    {
        private readonly ICollection<Item> _scannedItems = new List<Item>();
        private readonly IEnumerable<MultiBuyOffer> _offers;

        public Checkout()
        {
            _offers = new List<MultiBuyOffer>();
        }

        public Checkout(IEnumerable<MultiBuyOffer> offers)
        {
            _offers = offers;
        }

        public void ScanItem(Item item)
        {
            _scannedItems.Add(item);
        }

        public ICollection<Item> GetScannedItems()
        {
            return _scannedItems;
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            
            foreach (var offer in _offers)
            {
                totalPrice += offer.Apply(_scannedItems);
            }

            totalPrice += _scannedItems.Where(i => !i.OfferApplied).Sum(i => i.UnitPrice);

            return totalPrice;
        }
    }
}
