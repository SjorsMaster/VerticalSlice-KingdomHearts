using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {

    GameObject ObjectToAcces;

    void Start ()
    {
        ObjectToAcces = GameObject.Find("BallSpawner");
        InstantiateBall scriptToAccess = ObjectToAcces.GetComponent<InstantiateBall>();
    }
	
}
