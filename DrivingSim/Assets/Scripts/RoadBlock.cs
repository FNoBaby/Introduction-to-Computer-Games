using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("RoadBlock hit by: " + collision.gameObject.name);
    }
}
