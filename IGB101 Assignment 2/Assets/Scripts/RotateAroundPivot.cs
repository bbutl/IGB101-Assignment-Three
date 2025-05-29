using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    public Transform pivot;
    public float rotationSpeed = 90f; // Degrees per second
    private float totalRotation = 0f;
    private bool hasRotated = false;

    void Update()
    {
        if (hasRotated) return;

        // Calculate rotation for this frame
        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        // Clamp rotation to not exceed 90 degrees
        if (totalRotation + rotationThisFrame >= 90f)
        {
            rotationThisFrame = 90f - totalRotation;
            hasRotated = true;
        }

        // Perform rotation
        transform.RotateAround(pivot.position, Vector3.right, rotationThisFrame);
        totalRotation += rotationThisFrame;
    }
}
