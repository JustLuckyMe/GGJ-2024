using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public Transform playerHand; // Reference to the player's hand or camera
    public float scrollSpeed = 5f; // Adjust this value to control the scroll speed

    private Transform heldObject;
    private Outline lastInteractedOutline;


    void Update()
    {
        // Cast a ray from the camera's position in the direction it's facing
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Draw the ray as a red line in the scene for visualization
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red, 1f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            // Check if the hit object has an interactable component
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            BookInteract bookInteractable = hit.collider.GetComponent<BookInteract>();
            ToggleAnimation toggleAnimation = hit.collider.GetComponent<ToggleAnimation>();


            // Get the outline component of the interactable object
            Outline outline = hit.collider.GetComponent<Outline>();

            // If it's a new interactable, disable the outline of the last interacted object
            if (lastInteractedOutline != outline)
            {
                DisableOutline(lastInteractedOutline);
                lastInteractedOutline = outline;
            }

            // If the interactable has an outline, enable it
            if (outline != null)
            {
                EnableOutline(outline);
            }

            // Check for button press to pick up the interactable
            if (Input.GetMouseButtonDown(0) && interactable != null)
            {
                if (heldObject == null)
                {
                    // Pick up the object if not holding anything
                    PickUp(interactable.transform);
                }
                else
                {
                    // Drop the held object if already holding something
                    Drop();
                }
            }

            if (Input.GetMouseButton(0) && bookInteractable != null)
            {
                bookInteractable.OpenBook();
            }

            // Adjust the distance of the interactable based on the scroll wheel input
            if (heldObject != null)
            {
                float scrollInput = Input.GetAxis("Mouse ScrollWheel");
                AdjustDistance(scrollInput);

                // Check if the held object is a bowl and the hit object is the microwave
                if (heldObject.CompareTag("Bowl") && hit.collider.CompareTag("Microwave"))
                {
                    // Trigger the microwave animation
                    if (toggleAnimation != null)
                    {
                        toggleAnimation.OpenAnimation();
                    }
                }
            }

            if (Input.GetMouseButton(0) && toggleAnimation != null)
            {
                toggleAnimation.OpenAnimation();
            }
 

            /*
                        if (Physics.Raycast(ray, out hit, interactRange))
                        {
                            Debug.Log("Hit object: " + hit.collider.gameObject.name);
                            // ... rest of the code
                        }*/



        }
        else
        {
            // If not hitting anything, disable the outline of the last interacted object
            DisableOutline(lastInteractedOutline);
            lastInteractedOutline = null;

            // Drop the held object if clicking in empty space
            if (heldObject != null && Input.GetMouseButtonDown(0))
            {
                Drop();
            }

        }
    }

    void PickUp(Transform objectToPickUp)
    {
        // Set the object as a child of the player's hand
        heldObject = objectToPickUp;
        heldObject.SetParent(playerHand);

        // Disable the object's physics while held
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void Drop()
    {
        // Release the held object
        heldObject.SetParent(null);

        // Enable the object's physics after dropping
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        heldObject = null;
    }

    void EnableOutline(Outline outline)
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    void DisableOutline(Outline outline)
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    void AdjustDistance(float scrollInput)
    {
        // Adjust the distance of the held object along the camera's forward direction
        float distanceChange = scrollInput * scrollSpeed * Time.deltaTime;
        Vector3 newPosition = heldObject.position + Camera.main.transform.forward * distanceChange;

        // Clamp the distance to avoid getting too close or too far
        //float minDistance = 1f;
        float maxDistance = 10f;
        newPosition = Vector3.ClampMagnitude(newPosition - playerHand.position, maxDistance) + playerHand.position;
        heldObject.position = newPosition;
    }
}
