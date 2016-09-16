using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSURV
{
    class BaseModule
    {
        public double TimeScale { get; set; }
        public double Mass { get; set; }
        public double BaseDurability { get; set; }
        public double Durability { get; set; }//прочность
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public bool PassageWay { get; set; }//проход\коридор
        public double WearRate { get; set; }//скорость изнашивания
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public double EnergyConsumptionIdle { get; set; }
        public double EnergyConsumptionWork { get; set; }
        public double EnergyAmount { get; set; }
        public double EnergyCapacity { get; set; }
        public double BasePower { get; set; }
        public double Power { get { return BasePower * Efficiency * TimeScale; } }
        public double BaseEfficiency { get; set; }
        public double Efficiency { get {return BaseEfficiency*(Durability/BaseDurability);} }
        virtual  public void DoWork()
        {
            throw new Exception("NotImplemented");
        }
    }
}
