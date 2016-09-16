using UnityEngine;
using System.Collections;

public class BaseEngine : BaseModule {
    public Ship  ship;
    public float force;
    public float energyConsumpted;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        base.DoWork();
        if (EnergyReady )
        {
            if (EnergyAmount>0)
            {
                if (EnergyAmount>EnergyConsumptionWork )
                {
                    force = Power;
                    energyConsumpted = EnergyConsumptionWork;
                }
                else
                {
                    var work = EnergyAmount/EnergyConsumptionWork  ;
                    force = Power * work;
                    energyConsumpted = EnergyAmount;
                }
                ship.Forge += force;
                EnergyAmount -= energyConsumpted;
            }
            else
            {
                energyConsumpted = EnergyConsumptionIdle;
            }
        }
	}
}
