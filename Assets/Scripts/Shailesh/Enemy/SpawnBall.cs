using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {

    private GameObject ObjectToAcces;


    // Use this for initialization
    void Start ()
    {
        ObjectToAcces = GameObject.Find("BallSpawner");
        InstantiateBall scriptToAccess = ObjectToAcces.GetComponent<InstantiateBall>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
