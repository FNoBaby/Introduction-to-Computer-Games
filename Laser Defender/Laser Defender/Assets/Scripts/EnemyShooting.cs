using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float enemyLaserSpeed = 4f;
    [SerializeField] float shotTimer;
    [SerializeField] float minShotTime = 1f;
    [SerializeField] float maxShotTime = 3f;
    [SerializeField][Range(0, 1)] float shootingLaserVolume = 0.5f;
    [SerializeField] AudioClip shootingLaserSound;
    // Start is called before the first frame update
    void Start()
    {
        //first random value chosen for the delay
        shotTimer = Random.Range(minShotTime, maxShotTime);
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0)
        {
            GameObject enemyLaser = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = enemyLaser.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -enemyLaserSpeed);
            shotTimer = Random.Range(minShotTime, maxShotTime);
            enemyLaser.transform.Rotate(0, 0, 180);
            AudioSource.PlayClipAtPoint(shootingLaserSound, Camera.main.transform.position, shootingLaserVolume);
        }
    }
}
