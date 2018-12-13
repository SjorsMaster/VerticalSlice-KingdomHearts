using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : InstantiateBall
{
    [SerializeField]
    private float DistanceToWegren, RaycastEnemy, RaycastSides;
    public float Wegrenspeed;
    private Transform spawnpoint;
    // The target marker.
    public Transform target;
    
    // Angular speed in radians per sec.
    public float speed;

    //Vector3 playerPos;
    //GameObject player;

	
	// Update is called once per frame
	void Update ()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(1, 0, 1)) * RaycastSides, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * RaycastEnemy, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * RaycastEnemy, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * RaycastEnemy, Color.yellow);


        if (getDistanceFromPlayer() < DistanceToWegren)
        {
            RunAway(); 
        }
        //CheckDistanceFromPlayer();
        RotateTowardsPlayer();
        if (Input.GetKeyDown("o"))
        {
            Spawn(spawnpoint.position);
        }
    }

    void CheckDistanceFromPlayer()
    {
       
    }


    public float getDistanceFromPlayer()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        return dist;
    }

    void RunAway()
    {
        //raycast om te zien welke weg vrij is.
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, RaycastEnemy, layerMask))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RaycastEnemy, layerMask))
            {
                transform.Translate(Vector3.right * Wegrenspeed * Time.deltaTime);
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, RaycastEnemy, layerMask))
            {
                transform.Translate(Vector3.left * Wegrenspeed * Time.deltaTime);
            }
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RaycastEnemy, layerMask))
            {
                transform.Translate(Vector3.left * Wegrenspeed * Time.deltaTime);
            }
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RaycastEnemy, layerMask))
            {
                transform.Translate(Vector3.right * Wegrenspeed * Time.deltaTime);
            }
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, RaycastEnemy, layerMask))
            {
                transform.Translate(Vector3.right * Wegrenspeed * Time.deltaTime);
            }
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, RaycastEnemy, layerMask))
        {
            transform.Translate(Vector3.back * Wegrenspeed * Time.deltaTime);
        }


        /*if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RaycastSides, layerMask))
        {
            Debug.Log("Did Hit left");
            transform.Translate(Vector3.left * Wegrenspeed * Time.deltaTime);
        }


        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RaycastEnemy, Color.blue);
            transform.Translate(Vector3.forward * Wegrenspeed * Time.deltaTime);
        }
        */
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
