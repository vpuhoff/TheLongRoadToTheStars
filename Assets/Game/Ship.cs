using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    public float Speed;
    public float Forge;
    public float Accelerate;
    public float Mass;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < target.childCount ; i++)
        {
            var module = target.GetChild(i);
            foreach (var item in module.GetComponents<BaseModule>())
            {
                Mass += item.Mass;
            }
        }
	}
    public float gravity = 9.8f;
    public float altitude = 0;
    public float altdelta = 0;
    // Update is called once per frame
    void Update ()
    {
        Accelerate = Forge / Mass - GetGravity() / Mass;
        Speed = Speed + Accelerate * Time.deltaTime;
        altdelta = 0;
        altdelta = Speed * Mass;
        altitude += altdelta;
        if (gravity > 0)
        {
            if (altitude < 0)
            {
                altitude = 0;
                Speed = 0;
                Accelerate = 0;
            }
        }
        target.position = new Vector3(target.position.x, target.position.y, -altitude / 100000f);
        camera.position = new Vector3(target.position.x-2f, target.position.y+9f, target.position.z - 14f-4f*GetGravity());
        Forge = 0;
    }

    private  float GetGravity()
    {
       
        if (altitude >450000)
        {
            return 0;
        }
        else
        {
            return gravity * (1 - altitude / 450000f);
        }
    }

    public Transform camera;
    public Transform target;
    public Rect rect = new Rect(-150, 20, 100, 40);
    public Vector3 offset = new Vector3(0.1f, -0.1f, 0); // height above the target position

    void OnGUI()
    {
        var point = Camera.main.WorldToScreenPoint(target.position + offset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.Label(rect, target.name + ":" + (int)altdelta); // display its name, or other string
    }
}
