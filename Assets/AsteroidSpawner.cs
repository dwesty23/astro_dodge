using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnDelay = .3f;
    float nextTimeToSpawn = 0f;

    public GameObject asteroidPrefab;

    public Transform[] spawnPoints;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnAsteroid();
            nextTimeToSpawn = Time.time + spawnDelay;
        }    
    }

    void SpawnAsteroid()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(asteroidPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
