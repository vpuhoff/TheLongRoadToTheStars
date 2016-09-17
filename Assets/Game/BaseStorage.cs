using UnityEngine;
using System.Collections;

public class BaseStorage : BaseModule {
    public string ItemType;
    public float Volume;//Количество
    public float Capacity;//вместимость
    public float Put(float Amount)
    {
        if (Capacity - Volume > Amount)
        {
            Volume += Amount;
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
    public float Take(float Amount)
    {
        if (Volume > Amount)
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
                Amount = Volume;
                Volume -= Amount;
                return Amount;
            }
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Transform target;
    public Rect rect = new  Rect(-150, 20, 100, 40);
    public Vector3 offset = new Vector3(0.1f, -0.1f,0); // height above the target position

    void OnGUI()
    {
        var point = Camera.main.WorldToScreenPoint(target.position  + offset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.contentColor = Color.black;
        GUI.Label(rect, target.name+":"+(int)Volume); // display its name, or other string
    }
}
