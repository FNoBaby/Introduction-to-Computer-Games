using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        health -= other.GetComponent<DamageDealer>().GetDamage();

        other.GetComponent<DamageDealer>().GotHit();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
