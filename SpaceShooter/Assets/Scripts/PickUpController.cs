using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public int amount = 10;

    Rigidbody2D body;

    PlayerData data;

    public float speed = 10;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();

        //multiply speed by -2 to make negative value
        //Positive Y velocity ensures the enemy will move down the screen
        body.velocity = new Vector2(0, speed * -2);

        data = GetComponent<PlayerData>();
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            data.health += amount;
        }
        else if (collision.gameObject.CompareTag("Ammo"))
        {
            data.ammo += amount;
        }
        else if (collision.gameObject.CompareTag("Kill"))
        {
            Destroy(gameObject);
        }
    }
}
