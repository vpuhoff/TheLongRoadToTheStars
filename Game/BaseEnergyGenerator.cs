using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSURV
{
    class BaseEnergyGenerator:BaseStorage  
    {
        public double TransformationEfficiency { get; set; }
        override public void DoWork()
        {
            //base.DoWork();
            if (Volume>0)
            {
                if (EnergyAmount <EnergyCapacity )
                {
                    var FuelPortion = Power;
                    if (FuelPortion > Volume)
                    {
                        FuelPortion = Volume;
                    }
                    var FutureEnergy = FuelPortion * TransformationEfficiency;
                    if (EnergyAmount + FutureEnergy > EnergyCapacity)
                    {
                        var needenergy = EnergyCapacity - EnergyAmount;
                        var needfuel = needenergy / TransformationEfficiency;
                        FuelPortion = needfuel;
                        FutureEnergy = FuelPortion * TransformationEfficiency;
                        EnergyAmount += FutureEnergy;
                        Volume -= FuelPortion;
                    }
                    else
                    {
                        EnergyAmount += FutureEnergy;
                        Volume -= FuelPortion;
                    }
                }
            }
        }
    }
}
