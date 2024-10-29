using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Blue Config")]
public class EnemyBlueConfig : ScriptableObject
{
    [SerializeField] float movementSpeed = 2.5f;
    [SerializeField] Transform pathPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int nosOfEnemies = 2;
    [SerializeField] float enemySpawnDelay = 2f;


    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    public List<Transform> waypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public void SetPathPrefab(Transform pathPrefab)
    {
        this.pathPrefab = pathPrefab;
    }
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public int GetNosOfEnemies()
    {
        return nosOfEnemies;
    }

    public float GetEnemySpawnDelay()
    {
        return enemySpawnDelay;
    }

}
