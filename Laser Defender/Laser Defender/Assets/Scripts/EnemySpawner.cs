using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyConfig enemyConfig;

    [SerializeField] EnemyBlueConfig enemyBlueConfig;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyConfig.GetNosOfEnemies(); i++)
        {
            Instantiate(enemyConfig.GetEnemyPrefab(), enemyConfig.waypoints()[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(enemyConfig.GetEnemySpawnDelay());
        }

        for (int i = 0; i < enemyBlueConfig.GetNosOfEnemies(); i++)
        {
            Instantiate(enemyBlueConfig.GetEnemyPrefab(), enemyBlueConfig.waypoints()[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(enemyBlueConfig.GetEnemySpawnDelay());
        }

    }
}
