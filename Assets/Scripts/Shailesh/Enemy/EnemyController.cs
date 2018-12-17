using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : InstantiateBall
{
    [SerializeField]
    private float DistanceToWegren, RaycastEnemy, RaycastSides;
    public float Wegrenspeed, timer = 0, throwballtimer = 0;
    [SerializeField]
    int state = 0, actionState = 2, lastState;
    bool throwBal = false;

    // The target marker.
    public Transform target;
    
    // Angular speed in radians per sec.
    public float speed;


    // Update is called once per frame
    void Update ()
    {

        if(actionState == 1)
        {
            RunAway();
        }
        if(actionState == 2)
        {
            Attack();
            RotateTowardsPlayer();
        }


        timer += Time.deltaTime;

        if(timer > 3)
        {
            int randomNumber = Random.Range(1, 3);
            timer = 0;
            state = 0;
            lastState = randomNumber;
            ChooseRandomAction(randomNumber);
            if(randomNumber == 1)
            {
                transform.localRotation *= Quaternion.Euler(180, 0, 0);
            }
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * RaycastEnemy, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * RaycastEnemy, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * RaycastEnemy, Color.yellow);

    }

    void ChooseRandomAction(int number)
    {

        actionState = number;

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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RaycastEnemy, layerMask))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RaycastEnemy, layerMask))
            {
                //state = 1;
                transform.Translate(Vector3.right * Wegrenspeed * Time.deltaTime);
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, RaycastEnemy, layerMask))
            {
                //state = 2;
                transform.Translate(Vector3.left * Wegrenspeed * Time.deltaTime);
            }
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RaycastEnemy, layerMask))
            {
                //state = 3;
                transform.Translate(Vector3.left * Wegrenspeed * Time.deltaTime);
            }
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RaycastEnemy, layerMask))
            {
                //state = 4;
                transform.Translate(Vector3.right * Wegrenspeed * Time.deltaTime);
            }
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, RaycastEnemy, layerMask))
            {
                //state = 5;
                transform.Translate(Vector3.right * Wegrenspeed * Time.deltaTime);
            }
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RaycastEnemy, layerMask))
        {
            transform.Translate(Vector3.forward * Wegrenspeed * Time.deltaTime);
            //state = 6;
        }

    }

    void Hit()
    {

    }

    void Attack()
    {

        throwballtimer += Time.deltaTime;

        if(throwballtimer > 1)
        {
            Spawn(GameObject.Find("BallSpawner").transform.position);
            throwballtimer = 0;
            actionState = 0;
        }
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

        //Invoke("RotateTowardsPlayer", 3f);
    }
}
