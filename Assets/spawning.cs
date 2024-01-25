using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject collectiblePrefab;
    public int numberOfRows = 4;
    public int rocksPerRow = 7;
    public float gapBetweenRows = 3.0f; // Vertical spacing between rows
    public float rowLength = 10.0f; // Horizontal length of a row
    public float moveAmount = 1.0f;
    public float moveSpeed = 1.0f;
    public float spawnProbability = 0.7f;

    private List<Vector3> rockPositions;
    
    
    private float safeDistance = 1.0f;

    void Start()
    {
        rockPositions = new List<Vector3>();
        SpawnCollectibles();
        SpawnRocksInRows();
    }

    void SpawnRocksInRows()
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int rock = 0; rock < rocksPerRow; rock++)
            {
                if (Random.value <= spawnProbability)
                {
                        // Calculate position for each rock in a row, spread horizontally
                    float xPosition = ((rowLength / (rocksPerRow + 1)) * (rock + 1)) - (rowLength / 2); 
                    Vector3 spawnPosition = new Vector3(xPosition, row * gapBetweenRows-3, 0); // Use y for vertical positioning
                    GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

                    rockPositions.Add(spawnPosition);

                    StartCoroutine(MoveRock(asteroid));
                }
                
            }
        }
    }

    IEnumerator MoveRock(GameObject rock)
    {
        float timer = 0;
        int direction = 1; // Initial direction

        while (true)
        {
            rock.transform.Translate(new Vector3(moveSpeed * Time.deltaTime * direction, 0, 0));

            timer += Time.deltaTime;
            if (timer >= moveAmount)
            {
                direction *= -1; // Change direction
                timer = 0;
            }

            yield return null;
        }
    }

    void SpawnCollectibles()
    {
        int collectiblesSpawned = 0;
        while (collectiblesSpawned < 5)
        {
            float xPosition = Random.Range(-rowLength / 4, rowLength / 4);
            float yPosition = Random.Range(0, numberOfRows) * gapBetweenRows - 4;
            float zPosition = Random.Range(-0.5f, 0.5f);

            Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);

            if (IsPositionSafe(spawnPosition))
            {
                Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
                collectiblesSpawned++;
            }
        }
    }

    bool IsPositionSafe(Vector3 position)
    {
        foreach (Vector3 rockPosition in rockPositions)
        {
            if (Vector3.Distance(rockPosition, position) < safeDistance)
            {
                Debug.Log("Rock at " + rockPosition + " is too close to " + position);
                return false;
            }
        }
        return true;
    }
}
