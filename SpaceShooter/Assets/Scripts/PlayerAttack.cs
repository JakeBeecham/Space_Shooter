using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletObject;

    PlayerData data;

	void Start ()
    {
        data = GetComponent<PlayerData>();
	}
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            if (data.ammo > 0)
            {
                Instantiate(bulletObject, transform.position, Quaternion.identity);

                data.ammo--;
            }
        }
	}
}
