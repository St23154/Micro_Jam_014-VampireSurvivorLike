using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    private TrailRenderer tr;
    [SerializeField] LogicScript script1;

    void Start()
    {
        // Get the TrailRenderer component and store it in 'tr'
        tr = gameObject.GetComponent<TrailRenderer>();

        // Disable the TrailRenderer initially
        tr.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && script1._cooldown==false)
        {
            // Clear the trail
            

            // Enable the TrailRenderer
            tr.enabled = true;

            // Define a plane that intersects the object's position and faces away from the camera
            Plane objPlane = new Plane(Camera.main.transform.forward * -1, transform.position);

            // Create a ray from the mouse position
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
            {
                // Move the object to the point where the ray intersects the plane
                transform.position = mRay.GetPoint(rayDistance);
            }
        }
        else
        {
            // Disable the TrailRenderer when the mouse button is not pressed
            tr.Clear();
            tr.enabled = false;
        }
    }
}
