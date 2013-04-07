using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateIt.PCL.Interfaces
{
    public interface IBarcodeScanner
    {
        public int Scan(byte[] image);
    }
}
