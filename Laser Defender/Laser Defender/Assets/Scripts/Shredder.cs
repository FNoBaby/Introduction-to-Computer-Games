using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    //If "isTrigger" is checked, the object will not collide with other objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collider2D collision is a parameter that represents the object that hit the Shredder
        Destroy(collision.gameObject);
    }
}
