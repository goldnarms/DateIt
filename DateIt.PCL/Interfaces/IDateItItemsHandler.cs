using DateIt.PCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateIt.PCL.Interfaces
{
    public interface IDateItItemsHandler
    {
        void AddNewDateItItem(string name, int barcodeId, int days);

        IEnumerable<DateItItem> GetAllDateItItems();

        DateItItem GetDateItItemByBarcode(int p);
    }
}
