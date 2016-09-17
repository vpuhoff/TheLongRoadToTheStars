using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseMap : MonoBehaviour {

    public List<BaseCell> CellTemplates = new List<BaseCell>();
    public int x;
    public int y;
    public int w;
    public int h;
    public float  scale;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y;j++)
            {
                var Cell = Instantiate(CellTemplates[0]);
                Cell.transform.position = new Vector2((float)(i * w) / scale, (float)(j * h) / scale);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
