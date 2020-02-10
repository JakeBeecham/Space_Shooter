using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5;

    Rigidbody2D body;

    public GameObject ammoPickUp;

    public GameObject healthPickUp;

    PlayerData data;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();

        //multiply speed by -1 to make negative value
        //Negative Y velocity ensures the enemy will move down the screen
        body.velocity = new Vector2(0, speed * -1);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Kill"))
        {
            //destroy game object
            //game object refers to the game object which this script is attached to
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            //destroy game object
            //game object refers to the game object which this script is attached to
            Destroy(gameObject);

            PlayerData.OnEnemiesKilled();

            //pick a random number between 1 and 10
            int chance = Random.Range(1, 10);

            //if the number is even
            if (chance % 2 == 0)
            {
                Instantiate(ammoPickUp).transform.position = transform.position;
            }
            else //else the number is odd
            {
                Instantiate(healthPickUp).transform.position = transform.position;
            }
        }
    }
}
