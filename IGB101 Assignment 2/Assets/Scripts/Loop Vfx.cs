using UnityEngine;
using UnityEngine.VFX;

public class LoopingVFX : MonoBehaviour
{
    public VisualEffect vfx;
    public float loopInterval = 10f; // Time in seconds between loops

    private float timer;

    void Start()
    {
        vfx.Play();
        timer = loopInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            vfx.Stop();
            vfx.Play();
            timer = loopInterval;
        }
    }
}
