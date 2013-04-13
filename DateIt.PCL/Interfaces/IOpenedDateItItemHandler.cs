using DateIt.PCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateIt.PCL.Interfaces
{
    public interface IOpenedItemHandler
    {
        void OpenItem(DateItItem openedItem, DateTime dateTime);

        IEnumerable<OpenedItem> GetAll();
        void RemoveAll();
    }
}
