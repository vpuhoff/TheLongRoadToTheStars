using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSURV
{
    class Transporter:BaseModule 
    {
        public BaseStorage IN { get; set; }
        public BaseStorage OUT { get; set; }
        public double Amount { get; set; }
        override  public void DoWork()
        {
            if (Amount ==0 )
            {
                Amount=IN.Take(Power); 
            }
            if (Amount > 0)
            {
                Amount = Amount - OUT.Put(Amount);
            }
        }
    }
}
