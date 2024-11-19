using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Boolean looping = false;
    [SerializeField] List<EnemyConfig> enemyConfigList;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (EnemyConfig enemyConfig in enemyConfigList)
            {
                yield return new WaitForSeconds(2f);

                for (int i = 0; i < enemyConfig.GetNosOfEnemies(); i++)
                {
                    var newEnemy = Instantiate(enemyConfig.GetEnemyPrefab(), enemyConfig.waypoints()[0].transform.position, Quaternion.identity);
                    newEnemy.GetComponent<EnemyMovement>().setWaveConfig(enemyConfig);
                    yield return new WaitForSeconds(enemyConfig.GetEnemySpawnDelay());
                }

            }
        } while (looping);
    }
}
