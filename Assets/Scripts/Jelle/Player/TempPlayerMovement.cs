using UnityEngine;

public class TempPlayerMovement : MonoBehaviour {
    private Transform playerT;
    private Transform camT;
    private float playerMoveSpeed;
    public string facingDirection;
    public readonly string[] faces = {"Forward","Backwards","Right","Left"};
	// Use this for initialization
	void Start () {
        playerT = GetComponent<Transform>();
        camT = GameObject.Find("Main Camera").GetComponent<Transform>();
        playerMoveSpeed = 6.7f;
        facingDirection = faces[0];
	}
	
	// Update is called once per frame
	void Update () {
        //Input
        if (Input.GetKey(KeyCode.W))
        {
            playerT.Translate(0,0, playerMoveSpeed * Time.deltaTime);
            facingDirection = faces[0];
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerT.Translate(0, 0, -playerMoveSpeed * Time.deltaTime);
            facingDirection = faces[1];
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerT.Translate(playerMoveSpeed * Time.deltaTime, 0, 0);
            facingDirection = faces[2];
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerT.Translate(-playerMoveSpeed * Time.deltaTime, 0, 0);
            facingDirection = faces[3];
        }
        playerT.rotation = camT.rotation;
    }
}
