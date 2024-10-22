using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Log the name of the object that collided with the puddle
        Debug.Log("Puddle hit by: " + collision.gameObject.name);
    }
}
