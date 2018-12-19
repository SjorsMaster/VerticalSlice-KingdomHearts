using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    float thrust, speed = 20;
    bool goTo = false;
    Transform target;
    Rigidbody rigB;
    GameObject enemy;

    void Start()
    {
        transform.rotation = GameObject.Find("Temp_Opponent").transform.rotation;
        thrust = 20f;
        rigB = GetComponent<Rigidbody>();
        enemy = GameObject.Find("bovenlichaam");
    }

    void FixedUpdate()
    {
        if (!goTo)
        {
            transform.Translate(Vector3.forward * thrust * Time.deltaTime);
        }

        
        if (goTo == true)
        {
            rigB.isKinematic = true;
            transform.LookAt(enemy.transform);
            transform.Translate(0,0,speed * Time.deltaTime);
            Debug.Log("GoBack");
        }
    }

    public void ThrowBack()
    {
        target = GameObject.Find("Ball(Placeholder)(Clone)").transform;
        goTo = true;
    }

    private void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject, 0f);
        }
    }
}
