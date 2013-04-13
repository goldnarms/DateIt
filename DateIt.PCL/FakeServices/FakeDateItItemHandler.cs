using DateIt.PCL.Interfaces;
using DateIt.PCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateIt.PCL.FakeServices
{
    public class FakeDateItItemsHandler : IDateItItemsHandler
    {
        private Dictionary<int, DateItItem> _dictionary;
        public FakeDateItItemsHandler()
        {
            _dictionary = new Dictionary<int, DateItItem>();
        }

        public void AddNewDateItItem(string name, int barcodeId, int days)
        {
            _dictionary.Add(barcodeId, new DateItItem { BarcodeId = barcodeId, Name = name, ShelfLifeInDays = days });
        }


        public IEnumerable<DateItItem> GetAll()
        {
            return _dictionary.Select(kvp => kvp.Value);
        }


        public DateItItem GetByBarcode(int barcode)
        {
            DateItItem foundDateItItem;
            _dictionary.TryGetValue(barcode, out foundDateItItem);
            return foundDateItItem;
        }

        public void RemoveAll()
        {
            _dictionary.Clear();
        }

        public DateItItem GetByName(string name)
        {
            var item = _dictionary.SingleOrDefault(kvp => kvp.Value.Name.ToLower() == name.ToLower().Trim());
            if (item.Value != null)
                return item.Value;
            return null;

        }
    }
}
