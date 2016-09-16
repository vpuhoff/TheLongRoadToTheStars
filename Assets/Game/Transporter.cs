using UnityEngine;
using System.Collections;

public class Transporter : BaseModule
{
    public BaseStorage IN;
    public BaseStorage OUT;
    public LineRenderer lineRenderer;
    public float Amount;
    override public void DoWork()
    {
        base.DoWork();
        if (!EnergyReady )
        {
            return;
        }
        if (EnergyAmount>0)
        {
            if (EnergyAmount >= EnergyConsumptionWork)
            {
                if (Amount < Power)
                {
                    Amount = IN.Take(Power - Amount);
                }
                if (Amount > 0)
                {
                    Amount = Amount - OUT.Put(Amount);
                    EnergyAmount -= Amount * EnergyConsumptionWork;
                }
            }
            else
            {
                var workam = EnergyAmount / EnergyConsumptionWork;
                if (Amount < Power*workam )
                {
                    Amount = IN.Take(Power*workam  - Amount);
                }
                if (Amount > 0)
                {
                    Amount = Amount - OUT.Put(Amount);
                    EnergyAmount -= Amount * EnergyConsumptionWork;
                }
            }
        }
    }

    Vector3 posthis, posin, posout;
    // Use this for initialization
    void Start ()
    {
        DrawLine();
    }

    private void DrawLine()
    {
        posthis = this.transform.position  ;
        posin = IN.transform.position;
        posout = OUT.transform.position;
        lineRenderer.SetColors(Color.red, Color.blue);
        lineRenderer.SetPosition(0, new Vector3(posthis.x, posthis.y, posthis.z));
        lineRenderer.SetPosition(1, new Vector3(posin.x, posin.y, posin.z ));
        lineRenderer.SetPosition(2, new Vector3(posthis.x, posthis.y, posthis.z ));
        lineRenderer.SetColors(Color.blue, Color.red);
        lineRenderer.SetPosition(3, new Vector3(posout.x, posout.y, posout.z ));
        lineRenderer.SetPosition(4, new Vector3(posthis.x, posthis.y, posthis.z ));
    }

    // Update is called once per frame
    void Update () {
        DoWork();
        if (posthis!= this.transform.position|| posin != IN.transform.position || posout != OUT.transform.position)
        {
            DrawLine();
        }
        
    }
}
