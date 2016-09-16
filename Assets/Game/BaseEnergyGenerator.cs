using UnityEngine;
using System.Collections;

public class BaseEnergyGenerator : BaseStorage
{
    public float TransformationEfficiency;
    override public void DoWork()
    {
        base.DoWork();
        if (Volume > 0)
        {
            if (EnergyAmount < EnergyCapacity)
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
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DoWork();
    }
}
