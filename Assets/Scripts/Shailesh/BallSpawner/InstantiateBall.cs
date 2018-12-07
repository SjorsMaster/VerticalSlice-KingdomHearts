using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBall : MonoBehaviour
{

    private GameObject ball;


    public void Spawn(float x, float y, float z)
    {
        ball = Resources.Load("Ball(Placeholder)") as GameObject;
        Instantiate(ball, new Vector3(x, y, z), Quaternion.identity);
    }
	
	void Update () {
		
	}
}
