using DateIt.PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateIt.PCL.FakeServices
{
    public class FakeOpenedDateItItemHandler : IOpenedDateItItemHandler
    {
        public void OpenItem(Models.DateItItem openedItem, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.OpenedItem> GetAllOpenedDateItItems()
        {
            throw new NotImplementedException();
        }
    }
}
