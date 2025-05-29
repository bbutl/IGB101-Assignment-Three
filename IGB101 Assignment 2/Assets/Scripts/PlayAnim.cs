using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public Material material;
    public string propertyName = "_ScreenON";
    public float incrementValue = 1f; // Amount to increase
    public float interval = 0.5f; // Time in seconds between increments

    private float currentValue = 0f; // Current value of the property

    void Awake()
    {
        // Reset the shader property value to 0 on Awake
        if (material != null && material.HasProperty(propertyName))
        {
            material.SetFloat(propertyName, 0f);
            currentValue = 0f;
        }
        else
        {
            Debug.LogWarning($"Material or property '{propertyName}' not found.");
        }
    }

    void Start()
    {
        // Initialize the property value in the shader
        if (material != null && material.HasProperty(propertyName))
        {
            currentValue = material.GetFloat(propertyName);
        }

        // Start a repeating call to the IncrementProperty method
        InvokeRepeating(nameof(IncrementProperty), interval, interval);
    }

    void IncrementProperty()
    {
        if (material != null && material.HasProperty(propertyName))
        {
            currentValue += incrementValue; // Increment the value

            // Reset to 1 if the value reaches or exceeds 9
            if (currentValue >= 10f)
            {
                currentValue = .9f;
            }

            material.SetFloat(propertyName, currentValue); // Set the updated value in the shader
        }
        else
        {
            Debug.LogWarning($"Material or property '{propertyName}' not found.");
        }
    }
}
