using UnityEngine;
using System.Collections;

public class BaseModule : MonoBehaviour {
    public float TimeScale;
    public float Mass;
    public float BaseDurability;
    public float Durability;//прочность
    public string Name;
    public string Description;
    public string ImageName;
    public bool PassageWay;//проход\коридор
    public float WearRate;//скорость изнашивания
    public int SizeX;
    public int SizeY;
    public float EnergyConsumptionIdle;
    public float EnergyConsumptionWork;
    public bool EnergyReady;
    public float EnergyAmount;
    public float EnergyCapacity;
    public float BasePower;
    public float Power { get { return BasePower * Efficiency * TimeScale; } }
    public float BaseEfficiency;
    public float Efficiency { get { return BaseEfficiency * (Durability / BaseDurability); } }
    public float PutEnergy(float Amount)
    {
        if (EnergyCapacity - EnergyAmount > Amount)
        {
            EnergyAmount += Amount;
            return Amount;
        }
        else
        {
            if (EnergyCapacity - EnergyAmount == 0)
            {
                return 0;
            }
            else
            {
                Amount = EnergyCapacity - EnergyAmount;
                EnergyAmount += Amount;
                return Amount;
            }
        }
    }
    public float TakeEnergy(float Amount)
    {
        if (EnergyAmount > Amount)
        {
            EnergyAmount -= Amount;
            return Amount;
        }
        else
        {
            if (EnergyAmount == 0)
            {
                return 0;
            }
            else
            {
                Amount = EnergyAmount;
                EnergyAmount -= Amount;
                return Amount;
            }
        }
    }
    virtual public void DoWork()
    {
        if (EnergyAmount > EnergyConsumptionIdle )
        {
            EnergyAmount -= EnergyConsumptionIdle;
            EnergyReady = true;
        }
        else
        {
            EnergyReady = false;
        }
        TimeScale = Time.deltaTime;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
