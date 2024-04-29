using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawRate = 1f;

    private float spawRateBegin = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawRate);

        while(canSpawn)
        {
            yield return wait;

            spawRateBegin = spawRate;

            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemytoSpawn = enemyPrefabs[rand];

            Instantiate(enemytoSpawn, transform.position, Quaternion.identity);
        }
    }
}
