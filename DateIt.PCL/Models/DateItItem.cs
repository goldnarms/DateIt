using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateIt.PCL.Models
{
    public class DateItItem
    {
        public string Name { get; set; }
        public int BarcodeId { get; set; }
        public int ShelfLifeInDays { get; set; }
    }
}
