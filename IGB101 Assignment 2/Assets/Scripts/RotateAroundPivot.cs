using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    public Transform pivot;
    public float rotationSpeed = 90f; // Degrees per second
    public float interactionRadius = 3f; // Player interaction radius
    public bool openInward = true;

    private float currentRotation = 0f;
    private float targetRotation = 0f;
    private bool isRotating = false;

    void Update()
    {
        // Check if player presses E and is within range
        if (!isRotating && Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= interactionRadius)
                {
                    // Toggle target rotation
                    if (Mathf.Approximately(currentRotation, 0f))
                        targetRotation = openInward ? 90f : -90f;
                    else
                        targetRotation = 0f;

                    isRotating = true;
                }
            }
        }

        if (isRotating)
        {
            float direction = Mathf.Sign(targetRotation - currentRotation);
            float rotationThisFrame = rotationSpeed * Time.deltaTime * direction;

            // Clamp to avoid overshooting
            if (Mathf.Abs(currentRotation + rotationThisFrame - targetRotation) < 0.01f ||
                Mathf.Abs(rotationThisFrame) > Mathf.Abs(targetRotation - currentRotation))
            {
                rotationThisFrame = targetRotation - currentRotation;
                isRotating = false;
            }

            transform.RotateAround(pivot.position, Vector3.right, rotationThisFrame);
            currentRotation += rotationThisFrame;
        }
    }

    // Optional: Draw the interaction radius in the scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
