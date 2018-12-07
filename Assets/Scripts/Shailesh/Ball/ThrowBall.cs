using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    private float thrust;

    void Start()
    {
        thrust = 10f;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * thrust * Time.deltaTime);
    }
}
