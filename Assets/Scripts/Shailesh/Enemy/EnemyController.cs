using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : InstantiateBall
{
    [SerializeField]
    private Transform spawnpoint;
    // The target marker.
    public Transform target;
    
    // Angular speed in radians per sec.
    public float speed;

    //Vector3 playerPos;
    //GameObject player;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetPlayerPos();
        if (Input.GetKeyDown("o"))
        {
            Spawn(spawnpoint.position);
        }
	}

    void GetPlayerPos()
    {
        RotateTowardsPlayer();
    }

    void Hit()
    {

    }

    void Attack()
    {
    }

    void RotateTowardsPlayer()
    {
        Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        newDir.y = 0;
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Move()
    {

    }


}
