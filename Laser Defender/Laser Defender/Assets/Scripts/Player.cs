using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 4f;
    [SerializeField] float paddingX = 0.5f;
    [SerializeField] float paddingY = 1f;

    Vector2 minBounds;

    Vector2 maxBounds;
    void Start()
    {
        Camera gameCamera = Camera.main;

        minBounds = gameCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = gameCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //Obtains the input from the keyboard keys
        //Horizontal is the left and right keys
        var inputX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //Vertical is the up and down keys
        var inputY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //Time.deltaTime makes the movement framerate independent - will be the same speed on all PCs
        //speed is the speed of the movement

        //Updating the current position of the player
        var newXPosition = inputX + transform.position.x;
        var newYPosition = inputY + transform.position.y;

        //Clamp takes the Value, Min and Max
        //If the value is less than the min, it returns the min
        //If the value is more than the max, it returns the max
        //If the value is between the min and max, it returns the value
        var boundXPosition = Mathf.Clamp(newXPosition, minBounds.x + paddingX, maxBounds.x - paddingX);
        var boundYPosition = Mathf.Clamp(newYPosition, minBounds.y + paddingY, maxBounds.y - paddingY);

        //Updating the position of the player
        transform.position = new Vector2(boundXPosition, boundYPosition);
    }
}
