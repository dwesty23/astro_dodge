using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public float spawnDelay = .3f;
    float nextTimeToSpawn = 0f;

    public GameObject brickPrefab;

    public Transform[] spawnPoints;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnBrick();
            nextTimeToSpawn = Time.time + spawnDelay;
        }    
    }

    void SpawnBrick()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(brickPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
