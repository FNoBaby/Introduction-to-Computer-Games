using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{
    [SerializeField] float backgroundSpeed = 0.15f;
    Material material;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(0, backgroundSpeed);
        
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;

    }
}
