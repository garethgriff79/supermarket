using System.Collections.Generic;

namespace Supermarket
{
    public class Checkout
    {
        private readonly ICollection<Item> _scannedItems = new List<Item>();

        public void ScanItem(Item item)
        {
            _scannedItems.Add(item);
        }

        public ICollection<Item> GetScannedItems()
        {
            return _scannedItems;
        }
    }
}
