using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBall : MonoBehaviour
{
    private GameObject ball;
    
    public void Spawn(Vector3 Position)
    {
        ball = Resources.Load("Ball(Placeholder)") as GameObject;
        Instantiate(ball, Position, Quaternion.identity);
    }
	
}
