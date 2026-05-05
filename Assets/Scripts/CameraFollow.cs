using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // Drag player here
    public Vector3 offset = new Vector3(0, 10, -5); // Position relative to player
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position based on the player's current spot
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly interpolate between current position and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;

        // Optional: Ensure the camera is always looking at the player
        transform.LookAt(target); 
    }
}