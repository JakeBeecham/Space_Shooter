using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 25;
    public int damage;

	void Start ()
    {
        minDamage = Random.Range(1, 12);
        maxDamage = Random.Range(13, 25);
        damage = Random.Range(5, 25);
	}
	
	void Update ()
    {
		
	}
}
