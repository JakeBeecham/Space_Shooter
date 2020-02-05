using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    float horizontal;

    Rigidbody2D body;

    Vector3 nextPosition;

	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        //use Input.GetAxis to get the Horizontal input (A,D, Left Arrow, Right Arrow)
        //returns a value between -1 and 1 (-1 = moving left, 0 = not moving, 1 = moving right)
        horizontal = Input.GetAxis("Horizontal");

        //set our next position to be the direction we are moving * our speed * time pass since last update
        //movementSpeed * Time.deltaTime (moving a percentage of the speed every frame)
        nextPosition.x = horizontal * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //set the velocity of the object to move to our next position
        body.velocity = nextPosition;
    }
}
