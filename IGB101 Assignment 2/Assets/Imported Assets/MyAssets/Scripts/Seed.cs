using UnityEngine;

public class Seed : MonoBehaviour
{
    public string seedType;

    public GameObject hybridPrefab;
    public ParticleSystem breedEffect;

    public float requiredWaterMin = 45f;
    public float requiredWaterMax = 55f;
    public float requiredTempMin = 10f;
    public float requiredTempMax = 30f;

    public AudioClip combineSound;
    private bool hasBred = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBred) return;

        Seed otherSeed = other.GetComponent<Seed>();

        if (otherSeed != null && otherSeed != this && !otherSeed.hasBred)
        {
            hasBred = true;
            otherSeed.hasBred = true;

            if (seedType != otherSeed.seedType)
            {
                Vector3 spawnPos = (transform.position + otherSeed.transform.position) / 2f;

                if (breedEffect)
                    Instantiate(breedEffect, spawnPos, Quaternion.identity);

                if (combineSound != null)
                    AudioSource.PlayClipAtPoint(combineSound, spawnPos);

                if (hybridPrefab)
                    Instantiate(hybridPrefab, spawnPos + Vector3.up * 0.1f, Quaternion.identity);

                Destroy(gameObject);
                Destroy(otherSeed.gameObject);
            }
        }
    }
}
