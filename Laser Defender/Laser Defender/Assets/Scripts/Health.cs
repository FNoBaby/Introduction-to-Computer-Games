using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    [SerializeField] GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        health -= other.GetComponent<DamageDealer>().GetDamage();

        other.GetComponent<DamageDealer>().GotHit();

        if (health <= 0)
        {
            //Spawn the explosion, then destroy after 0.1 seconds

            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.1f);
            Destroy(gameObject, 0.1f);
        }
    }

}
