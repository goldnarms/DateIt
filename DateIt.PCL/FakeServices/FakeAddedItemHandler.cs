using System.Collections.Generic;
using System.Linq;
using DateIt.PCL.Interfaces;
using DateIt.PCL.Models;

namespace DateIt.PCL.FakeServices
{
    public class FakeAddedItemHandler : IAddedItemHandler
    {
        private Dictionary<string, DateItItem> _dictionary;

        public FakeAddedItemHandler()
        {
            _dictionary = new Dictionary<string, DateItItem>();
        }
        public void Add(DateItItem dateItItem)
        {
            if(!_dictionary.ContainsKey(dateItItem.Name))
                _dictionary.Add(dateItItem.Name, dateItItem);
        }

        public IEnumerable<DateItItem> GetAll()
        {
            return _dictionary.Select(kvp => kvp.Value);
        }

        public DateItItem GetByBarcode(int barcodeId)
        {
            return _dictionary.SingleOrDefault(kvp => kvp.Value.BarcodeId == barcodeId).Value;
        }

        public bool Contains(DateItItem dateItItem)
        {
            return _dictionary.ContainsValue(dateItItem);
        }
    }
}