using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public List<GameObject> objectsToSpawn;
    public float spawnIntervalMin = 2f;
    public float spawnIntervalMax = 5f;

    [Header("Seed Limit Settings")]
    public string seedTag = "Seed";
    public int maxSeedCount = 30;

    [Header("Tag for Spawn Locations")]
    public string spawnLocationTag = "SpawnerLoc";

    public List<Transform> spawnLocations = new List<Transform>();

    private void Awake()
    {
        GameObject[] locationObjects = GameObject.FindGameObjectsWithTag(spawnLocationTag);
        foreach (GameObject obj in locationObjects)
        {
            spawnLocations.Add(obj.transform);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int currentSeedCount = GameObject.FindGameObjectsWithTag(seedTag).Length;

            if (currentSeedCount < maxSeedCount && objectsToSpawn.Count > 0 && spawnLocations.Count > 0)
            {
                SpawnRandomObjectAtRandomLocation();
            }

            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SpawnRandomObjectAtRandomLocation()
    {
        GameObject objToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        Transform spawnPoint = spawnLocations[Random.Range(0, spawnLocations.Count)];

        Instantiate(objToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
