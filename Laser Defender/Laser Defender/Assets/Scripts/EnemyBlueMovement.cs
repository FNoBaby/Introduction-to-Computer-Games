using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueMovement : MonoBehaviour
{
    int index = 0;

    [SerializeField] EnemyBlueConfig enemyConfigFile;

    List<Transform> waypoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        waypoints = enemyConfigFile.waypoints();
        transform.position = waypoints[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (index <= waypoints.Count - 1)
        {   
            //targetPosition is the position of the next waypoint
            var targetPosition = waypoints[index].transform.position;
            //movementThisFrame is the distance the enemy will move this frame
            var movementThisFrame = enemyConfigFile.GetMovementSpeed() * Time.deltaTime;

            //MoveTowards moves the enemy towards the targetPosition by movementThisFrame
            //If the enemy is already at the targetPosition, index is incremented to move to the next waypoint
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.transform.position == targetPosition)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
