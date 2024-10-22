using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementspeed = 5f;
    [SerializeField] float paddingX = 0.5f;
    [SerializeField] float paddingYBottom = 2f;

    [SerializeField] float paddingYTop = 25f;

    Vector2 minBounds;
    Vector2 maxBounds;

    // Start is called before the first frame update
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

        //Horizontal - left/right arrows
        var inputX = Input.GetAxis("Horizontal") * Time.deltaTime * movementspeed;
        //Vertical - up/down arrows
        var inputY = Input.GetAxis("Vertical") * Time.deltaTime * movementspeed;
        //time deltatime will make our game frame indipendent.
        //the same speed on all PC's.

        //Updated the current x Position of the player by adding the keyboard input.
        var newXposition = inputX + transform.position.x;
        var newYposition = inputY + transform.position.y;
        // this will be used to move the players to the right and up.

        //Clamp eunsure that the current X position of the player does not exceed Min and Max Bounds
        var boundXpos = Mathf.Clamp(newXposition, minBounds.x + paddingX, maxBounds.x - paddingX);
        var boundYpos = Mathf.Clamp(newYposition, minBounds.y + paddingYBottom, maxBounds.y - paddingYTop);
        //Padding is set to add extra space between the player and the border.

        //Provides the updated values to the Player's object.
        transform.position = new Vector2(boundXpos, boundYpos);
    }
}
