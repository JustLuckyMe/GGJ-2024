using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2f;
    public float verticalRotationLimit = 80f; // Adjust this value to set the maximum and minimum vertical rotation angles
    public float horizontalRotationLimit = 180f; // Adjust this value to set the maximum horizontal rotation angle

    private float rotationX = 0f;

    public bool canMove = true;

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // Hide the cursor
        Cursor.visible = false;
    }

    void Update()
    {
        if (canMove)
        {
            // Get mouse input for camera rotation
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // Rotate the camera horizontally (around the y-axis)
            transform.Rotate(Vector3.up * mouseX);

            // Rotate the camera vertically (around the x-axis), limited to the specified range
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -verticalRotationLimit, verticalRotationLimit);

            transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);

            // Clamp the total rotation around the y-axis
            float totalRotationY = transform.localRotation.eulerAngles.y;
            totalRotationY = totalRotationY > 180f ? totalRotationY - 360f : totalRotationY; // Convert to -180 to 180 range
            totalRotationY = Mathf.Clamp(totalRotationY, -horizontalRotationLimit, horizontalRotationLimit);

            transform.localRotation = Quaternion.Euler(rotationX, totalRotationY, 0f);

            /*        // For example, you may want to unlock the cursor when the player presses the Escape key
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ToggleCursorLock();
                    }*/
        }
    }

    void ToggleCursorLock()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // Unlock the cursor
            Cursor.lockState = CursorLockMode.None;
            // Show the cursor
            Cursor.visible = true;
        }
        else
        {
            // Lock the cursor to the center of the screen
            Cursor.lockState = CursorLockMode.Locked;
            // Hide the cursor
            Cursor.visible = false;
        }
    }
}
