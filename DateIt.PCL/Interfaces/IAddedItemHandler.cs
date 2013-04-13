using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateIt.PCL.Models;

namespace DateIt.PCL.Interfaces
{
    public interface IAddedItemHandler
    {
        void Add(DateItItem dateItItem);
        IEnumerable<DateItItem> GetAll();
        DateItItem GetByBarcode(int barcodeId);
        bool Contains(DateItItem dateItItem);
    }
}
