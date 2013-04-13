using DateIt.PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateIt.PCL.Models;

namespace DateIt.PCL.FakeServices
{
    public class FakeOpenedDateItItemHandler : IOpenedItemHandler
    {
        private readonly IAddedItemHandler _addedItemHandler;
        private Dictionary<int, OpenedItem> _dictionary;

        public FakeOpenedDateItItemHandler()
        {
            _dictionary = new Dictionary<int, OpenedItem>();
        }

        public FakeOpenedDateItItemHandler(IAddedItemHandler addedItemHandler)
        {
            _dictionary = new Dictionary<int, OpenedItem>();
            _addedItemHandler = addedItemHandler;
        }

        public void OpenItem(DateItItem openedItem, DateTime dateTime)
        {
            _dictionary.Add(_dictionary.Count + 1, new OpenedItem {DateOpened = dateTime, DateItItem = openedItem});
            if(!_addedItemHandler.Contains(openedItem))
                _addedItemHandler.Add(openedItem);
        }

        public IEnumerable<OpenedItem> GetAll()
        {
            return _dictionary.Select(kvp => kvp.Value);
        }

        public void RemoveAll()
        {
            _dictionary.Clear();
        }
    }
}
