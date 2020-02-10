using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10;

    Rigidbody2D body;

	void Start ()
    {
        body = GetComponent<Rigidbody2D>();

        //multiply speed by 1 to make positive value
        //Positive Y velocity ensures the enemy will move up the screen
        body.velocity = new Vector2(0, speed * 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            //destroy game object
            //game object refers to the game object which this script is attached to
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Asteroid"))
        {
            //destroy game object
            //game object refers to the game object which this script is attached to
            Destroy(gameObject);
        }
    }
}
