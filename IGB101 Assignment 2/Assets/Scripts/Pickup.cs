using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameManager gameManager;
    MeshRenderer meshRenderer;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.currentPickups += 1;

            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }

            Collider col = GetComponent<Collider>();
            if (col != null)
            {
                col.enabled = false;
            }
        }
    }
}
