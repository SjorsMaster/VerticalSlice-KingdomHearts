using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    private float thrust;


    void Start()
    {
        transform.rotation = GameObject.Find("Enemy").transform.rotation;
        thrust = 20f;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * thrust * Time.deltaTime);
    }

    void ThrowBack()
    {
        //schiet de bal richting de lockon
    }

    private void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            Destroy(this.gameObject, 0f);
        }
    }
}
