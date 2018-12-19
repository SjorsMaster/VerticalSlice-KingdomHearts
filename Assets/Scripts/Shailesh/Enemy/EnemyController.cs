using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : InstantiateBall
{
    [SerializeField]
    float DistanceToWegren, 
          RaycastEnemy, 
          RaycastSides, 
          Wegrenspeed, 
          timer = 0, 
          throwballtimer = 0,
          speed;
    
    [SerializeField]
    int state = 0, 
        actionState = 2, 
        lastState;

    bool throwBal = false;
    
    [SerializeField]
    Transform target;

    void Update ()
    {
        if(actionState == 1 || actionState == 2 || actionState == 3)
        {
            RunAway();
        }
        if(actionState == 0)
        {
            Attack();
            RotateTowardsPlayer();
        }
        timer += Time.deltaTime;
        if(timer > 3)
        {
            int randomNumber = Random.Range(0,3);// 0\4 = idle, 2 = attack, 1/3/5 = walk;
            if(randomNumber != lastState)
            {
                lastState = randomNumber;
                timer = 0;
                ChooseRandomAction(randomNumber);
                if (randomNumber == 1)
                {
                    transform.localRotation *= Quaternion.Euler(0, 180, 0);
                }
            }
            else
            {
                timer = 3;
            }

        }
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
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RaycastEnemy, layerMask))
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
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RaycastEnemy, layerMask))
        {
            transform.Translate(Vector3.forward * Wegrenspeed * Time.deltaTime);
        }

    }

    void Hit()
    {

        //play hit animation!
    }

    void Attack()
    {

        throwballtimer += Time.deltaTime;

        if(throwballtimer > 1)
        {
            Spawn(GameObject.Find("BallSpawner").transform.position);
            throwballtimer = 0;
            actionState = 5;
            timer = 0;
        }
    }



    void RotateTowardsPlayer()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        newDir.y = 0;
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
