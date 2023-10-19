using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObject;

    public float spawnTime = 1f;
    public bool canSpawn = true;
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    public IEnumerator spawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnTime);

        while (canSpawn)
        {
            yield return wait;
            Instantiate(spawnObject, transform.position, Quaternion.identity);
        }
    } 

}
