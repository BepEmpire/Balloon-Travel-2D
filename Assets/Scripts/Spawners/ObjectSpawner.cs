using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private float yRange = 4.5f;
    [SerializeField] private float minSpawnInterval = 3f;
    [SerializeField] private float maxSpawnInterval = 5f;

    private bool _isSpawnStart;
    
    private void Start()
    {
        _isSpawnStart = true;
        StartCoroutine(SpawnObjects());
    }

    public void StopSpawn()
    {
        _isSpawnStart = false;
        StopCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (_isSpawnStart)
        {
            yield return new WaitForSeconds(SpawnInterval());

            if (spawnObjects.Length > 0)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, RandomYRange(), transform.position.z);
                GameObject currentItem = Instantiate(GetRandomObject(), transform);

                currentItem.transform.position = spawnPosition;
            }
        }
    }

    private float SpawnInterval()
    {
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }
    
    private float RandomYRange()
    {
        return Random.Range(-yRange, yRange);
    }

    private GameObject GetRandomObject()
    {
        return spawnObjects[Random.Range(0, spawnObjects.Length)];
    }
}