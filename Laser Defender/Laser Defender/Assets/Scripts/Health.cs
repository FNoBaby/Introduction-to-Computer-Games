using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    [SerializeField] GameObject explosionPrefab;

    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.5f;

    [SerializeField] AudioClip deathSound;

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

            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);

            if (gameObject.tag == "Player")
            {
                FindObjectOfType<Level>().LoadGameOver();
            }
        }
    }

}
