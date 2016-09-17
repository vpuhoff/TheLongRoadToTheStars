using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed;
    private Vector3 targetPosition;
    private Transform _transform;
    void Start()
    {
        _transform = transform;
    }

    void Update ()
    {
        // Check if the left mouse button was clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Create a Ray object at the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Create a RayCastHit property to get the output from RayCast
            RaycastHit hit;
            // Get the RayCast hit from the mouse position to the direction it is pointing at
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Targetable")
                {
                    _transform = hit.collider.transform;
                    //_transform.renderer.material.color = Color.red;
                }
                else
                {
                    // Create a plane at the current position
                    Plane plane = new Plane(Vector3.up, _transform.position);
                    // Get the RayCast hit from the mouse position to the direction it is pointing at
                    float hitdist;
                    // Check if the ray was at a valid position
                    if (plane.Raycast(ray, out hitdist))
                    {
                        // Get the point where the ray hit
                        targetPosition = ray.GetPoint(hitdist);
                        // Face the transform at the hit location
                        transform.rotation = Quaternion.FromToRotation(_transform.position,targetPosition - _transform.position);
                    }
                }
            }
        }
        // Move the transform to the target position until it is close enough to it
        if (Vector3.Distance(_transform.position, targetPosition) > 0.1f)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, Time.deltaTime * speed);
        }
    }
}
