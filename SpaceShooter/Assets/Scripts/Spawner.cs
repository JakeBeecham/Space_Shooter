using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToBeSpawned;

    BoxCollider2D spawnArea;

    Vector3 randomPosition;

    float elapsedTime = 0;
    public float spawnTime = 2;

	void Start ()
    {
        spawnArea = GetComponent<BoxCollider2D>();
	}
	
	void Update ()
    {
        elapsedTime += Time.deltaTime;

        //if elapsed time is greater than or equal to event time, play the audio
        if (elapsedTime >= spawnTime)
        {
            //Call Spawn Object method to create asteroid
            SpawnObject();

            //reset timer
            elapsedTime = 0;

            spawnTime = Random.Range(2, 5);//random time between 2 and 5 seconds
        }
    }

    Vector3 PickRandomPosition()
    {
        //bounds.min is the leftmost position of the box
        //bounds.max is the rightmost position of the box
        float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float y = transform.position.y;

        return new Vector3(x, y, 0);
    }

    void SpawnObject()
    {
        randomPosition = PickRandomPosition();
        //clone the objectToBeSpawned and position it at the random position
        Instantiate(objectToBeSpawned, randomPosition, Quaternion.identity);
    }
}
