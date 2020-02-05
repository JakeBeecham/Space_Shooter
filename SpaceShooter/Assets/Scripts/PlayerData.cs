using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    int health;
    public int startingHealth = 100;
    public int lives = 5;
    public int ammo = 100;

    EnemyData data;

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
    }
}
