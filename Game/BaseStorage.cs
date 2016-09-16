using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSURV
{
    class BaseStorage:BaseModule 
    {
        public string ItemType { get; set; }
        public double Volume { get; set; }//Количество
        public double Capacity { get; set; }//вместимость
        public double Put( double Amount)
        {
            if (Capacity - Volume > Amount)
            {
                Volume  += Amount;
                return Amount;
            }
            else
            {
                if (Capacity - Volume == 0)
                {
                    return 0;
                }
                else
                {
                    Amount = Capacity - Volume;
                    Volume += Amount;
                    return Amount;
                }
            }
        }
        public double Take( double Amount)
        {
            if ( Volume > Amount)
            {
                Volume -= Amount;
                return Amount;
            }
            else
            {
                if (Volume == 0)
                {
                    return 0;
                }
                else
                {
                    Amount =  Volume;
                    Volume -= Amount;
                    return Amount;
                }
            }
        }
    }
}
