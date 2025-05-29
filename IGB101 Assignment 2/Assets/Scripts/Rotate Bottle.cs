using System.Collections;
using UnityEngine;

public class RotateBottle : MonoBehaviour
{
    public float rotationDuration = 5.0f; // Duration per axis rotation

    private void Start()
    {
        StartCoroutine(RotateSequentially());
    }

    private IEnumerator RotateSequentially()
    {
        while (true)
        {
            yield return RotateAxis(Vector3.right);    // X axis
            yield return RotateAxis(Vector3.forward);  // Z axis
        }
    }

    private IEnumerator RotateAxis(Vector3 axis)
    {
        float elapsed = 0f;
        float currentAngle = 0f;

        while (elapsed < rotationDuration)
        {
            float delta = 360f * (Time.deltaTime / rotationDuration);
            transform.Rotate(axis, delta, Space.Self);
            elapsed += Time.deltaTime;
            currentAngle += delta;
            yield return null;
        }

        float correction = 360f - currentAngle;
        if (correction != 0f)
            transform.Rotate(axis, correction, Space.Self);
    }
}
