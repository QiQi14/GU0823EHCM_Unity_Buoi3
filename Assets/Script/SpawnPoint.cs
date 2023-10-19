using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public Vector2 xRange;  // Khoảng giới hạn cho trục X
    public Vector2 yRange;  // Khoảng giới hạn cho trục Y
    public Vector2 zRange;  // Khoảng giới hạn cho trục Z
    public int numberOfPrefabsPerWave; // Số lượng prefab trong mỗi đợt
    public float timeBetweenWaves;     // Thời gian giữa các đợt

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < numberOfPrefabsPerWave; i++)
            {
                SpawnObject();
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(xRange.x, xRange.y),
                Random.Range(yRange.x, yRange.y),
                Random.Range(zRange.x, zRange.y)
            );

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab not assigned!");
        }
    }
}
