using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour {
    private Transform playerT;
    private float playerMoveSpeed;
	// Use this for initialization
	void Start () {
        playerT = GetComponent<Transform>();
        playerMoveSpeed = 6.7f;
	}
	
	// Update is called once per frame
	void Update () {
        //Input
        if (Input.GetKey(KeyCode.W))
        {
            playerT.Translate(0,0, playerMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerT.Translate(0, 0, -playerMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerT.Translate(playerMoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerT.Translate(-playerMoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
