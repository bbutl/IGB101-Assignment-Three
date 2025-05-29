using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    public Transform pivot;
    public float rotationSpeed = 90f; // Degrees per second
    private float totalRotation = 0f;
    private bool hasRotated = false;
    public bool openInward = true;

    void Update()
    {
        if (hasRotated) return;

        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        if (openInward)
        {
            if (totalRotation + rotationThisFrame >= 90f)
            {
                rotationThisFrame = 90f - totalRotation;
                hasRotated = true;
            }
            transform.RotateAround(pivot.position, Vector3.right, rotationThisFrame);
            totalRotation += rotationThisFrame;
        }
        else
        {
            rotationThisFrame *= -1f; // Invert direction

            if (totalRotation + rotationThisFrame <= -90f)
            {
                rotationThisFrame = -90f - totalRotation;
                hasRotated = true;
            }
            transform.RotateAround(pivot.position, Vector3.right, rotationThisFrame);
            totalRotation += rotationThisFrame;
        }
    }
}
