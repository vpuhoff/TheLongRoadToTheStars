using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseEnergyDispenser : BaseModule
{
    public List<BaseModule>  IN = new List<BaseModule>();
    public List<BaseModule> OUT = new List<BaseModule>();
    public LineRenderer lineRenderer;
    override public void DoWork()
    {
        base.DoWork();
        var needpower = Power;
        float  powertaked = 0;
        var powerperin = needpower / IN.Count;
        var powerperout = needpower / OUT.Count;
        if (EnergyAmount < needpower)
        {
            foreach (BaseModule INitem in IN)
            {
                if (powertaked + powerperin < needpower)
                {
                    var taked = INitem.TakeEnergy(powerperin);
                    powertaked += taked;
                }
                else
                {
                    var taked = INitem.TakeEnergy(needpower - powertaked);
                    powertaked += taked;
                }
            }
            EnergyAmount += powertaked;
        }
        foreach (BaseModule OUTitem in OUT)
        {
            if (EnergyAmount>0)
            {
                if (OUTitem!=null )
                {
                    if (OUTitem.EnergyAmount < OUTitem.EnergyCapacity)
                    {
                        if (EnergyAmount > powerperout)
                        {
                            var putted = OUTitem.PutEnergy(powerperout);
                            EnergyAmount -= putted;
                        }
                        else
                        {
                            var putted = OUTitem.PutEnergy(EnergyAmount);
                            EnergyAmount -= putted;
                        }
                    }
                }
            }
        }
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DoWork();
    }
}
