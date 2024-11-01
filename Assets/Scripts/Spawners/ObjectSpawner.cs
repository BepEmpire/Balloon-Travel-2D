using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private float yRange = 4.5f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnInterval());

            if (spawnObjects.Length > 0)
            {
                GameObject objectToSpawn = spawnObjects[Random.Range(0, spawnObjects.Length)];
                Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(-yRange, yRange), transform.position.z);
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }

    private float SpawnInterval()
    {
        GameObject objectType = spawnObjects[0];
        
        if (objectType.CompareTag("Item"))
        {
            return Random.Range(3f, 5f);
        }
        else if (objectType.CompareTag("Coin"))
        {
            return Random.Range(8f, 12f);
        }
        else if (objectType.CompareTag("Skull"))
        {
            return Random.Range(15f, 21f);
        }

        return 1f;
    }
}
