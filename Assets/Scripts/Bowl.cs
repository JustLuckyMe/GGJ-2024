using UnityEngine;

public class Bowl : MonoBehaviour
{
    private bool isLocked = true;

    // Update is called once per frame
    void Update()
    {
        // Check if the object is locked
        if (isLocked)
        {
            // Object is locked, it won't perform its usual actions
            Debug.Log("Object is locked. Waiting for toggle...");
        }
        else
        {
            // Object is unlocked, perform its usual actions
            PerformObjectActions();
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLock();
        }
    }

    void PerformObjectActions()
    {
        // Implement the usual actions the object should perform when unlocked
        Debug.Log("Performing object actions...");
    }

    void ToggleLock()
    {
        // Toggle the lock state
        isLocked = !isLocked;

        // Print a message to indicate the lock state change
        if (isLocked)
        {
            Debug.Log("Object is now locked.");
        }
        else
        {
            Debug.Log("Object is now unlocked.");
        }
    }
}
