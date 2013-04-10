using DateIt.PCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateIt.PCL.Interfaces
{
    public interface IOpenedDateItItemHandler
    {
        void OpenItem(Models.DateItItem openedItem, DateTime dateTime);

        IEnumerable<OpenedItem> GetAllOpenedDateItItems();
    }
}
