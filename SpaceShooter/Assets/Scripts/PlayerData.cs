using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public int health;
    public int startingHealth = 100;
    public int lives = 5;
    public int ammo = 100;

    EnemyData data;

    public static int enemiesKilled;

	void Start ()
    {
        health = startingHealth;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            data = collision.gameObject.GetComponent<EnemyData>();
            health -= data.damage;

            if(health <= 0)
            {
                lives--;

                if(lives <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }

                health = startingHealth;
            }
        }
        else if (collision.gameObject.tag == "Ammo")
        {
            //get the pickup controller and use the amount variable it has
            PickUpController pickup = collision.gameObject.GetComponent<PickUpController>();
            ammo += pickup.amount;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Health")
        {
            //get the pickup controller and use the amount variable it has
            PickUpController pickup = collision.gameObject.GetComponent<PickUpController>();
            health += pickup.amount;
            Destroy(collision.gameObject);
        }
    }

    public static void OnEnemiesKilled()
    {
        enemiesKilled++;
    }
}
