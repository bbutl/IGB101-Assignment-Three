using UnityEngine;
using UnityEngine.VFX;

public class LoopingVFX : MonoBehaviour
{
    public VisualEffect vfx;

    void Start()
    {
        // Start looping
        vfx.Play();
    }

    void Update()
    {
        // Stop looping with S
        if (Input.GetKeyDown(KeyCode.S))
        {
            vfx.Stop();
        }

        // Restart with Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vfx.Play();
        }
    }
}