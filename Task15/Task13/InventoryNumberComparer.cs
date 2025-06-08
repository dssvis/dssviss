using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13;

namespace Task14
{
    public class InventoryNumberComparer : IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            return x.InventoryNumber.CompareTo(y.InventoryNumber);
        }
    }
}
