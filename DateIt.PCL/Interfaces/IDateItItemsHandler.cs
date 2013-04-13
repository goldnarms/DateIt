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

        IEnumerable<DateItItem> GetAll();

        DateItItem GetByBarcode(int p);
        void RemoveAll();
        DateItItem GetByName(string appelsinjuice);
    }
}
