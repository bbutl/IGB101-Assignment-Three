using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    GameManager gameManager;
    MeshRenderer meshRenderer;
    AudioSource audioSource;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.currentPickups += 1;

            if (meshRenderer != null)
                meshRenderer.enabled = false;

            Collider col = GetComponent<Collider>();
            if (col != null)
                col.enabled = false;

            if (audioSource != null)
                StartCoroutine(MuteAudioAfterDelay(1f));
        }
    }

    IEnumerator MuteAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.mute = true;
    }
}
