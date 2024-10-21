using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 4f;
    [SerializeField] float paddingX = 0.5f;
    [SerializeField] float paddingY = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 10f;

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
        Fire();
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

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate creates a new object
            //The first parameter is the object to create
            //The second parameter is the position of the object
            //The third parameter is the rotation of the object
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            //GetComponent allows us to access the component of the object
            //Rigidbody2D is the component that allows the object to move
            // Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

            //AddForce applies a force to the object
            //The first parameter is the direction of the force
            //The second parameter is the amount of force
            // rb.AddForce(Vector2.up * laserSpeed);

            //The above code is the same as the code below
            //The difference is that the code below is more efficient
            //The code below does not require the object to have a Rigidbody2D component
            //The code below moves the object using the transform component
            //The code below moves the object using the position of the object
            //The code below moves the object using the speed of the object
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f , laserSpeed);

            //Destroy destroys the object after a certain amount of time
            //The first parameter is the object to destroy
            //The second parameter is the time to wait before destroying the object
            // if(laser.GetComponent<Rigidbody2D>().position.y > maxBounds.y || laser.GetComponent<Rigidbody2D>().position.y < minBounds.y){
            //     Destroy(laser , 1f);
            // }
        }
    }
}
