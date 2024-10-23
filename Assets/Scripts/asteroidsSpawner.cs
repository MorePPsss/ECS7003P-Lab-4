using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsSpawner : MonoBehaviour
{
    public float xMin = -3f;
    public float xMax = 3f;
    public float yMin = -5f;
    public float yMax = 5f;

    [SerializeField] private float spawnRate = 0.5f;
    private float nextSpawnTime = 0f;

    public Object asteroidPrefab;
    

    private void spawnAsteroid()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xMin,xMax), 0.5f, transform.position.z);
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            spawnAsteroid();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
