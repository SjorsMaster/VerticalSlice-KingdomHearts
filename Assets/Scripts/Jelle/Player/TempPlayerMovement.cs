using UnityEngine;

public class TempPlayerMovement : MonoBehaviour {
    private Transform playerT;
    private Transform camT;
    private float playerMoveSpeed;
    private PlayerFightSystem scriptRefFight;
	// Use this for initialization
	void Start () {
        playerT = GetComponent<Transform>();
        camT = GameObject.Find("Main Camera").GetComponent<Transform>();
        scriptRefFight = GetComponent<PlayerFightSystem>();
        playerMoveSpeed = 6.7f;
	}
	
	// Update is called once per frame
	void Update () {
        //Input
        if (!scriptRefFight.attackActive)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movePlayer(1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                movePlayer(2);
            }
            if (Input.GetKey(KeyCode.D))
            {
                movePlayer(3);
            }
            if (Input.GetKey(KeyCode.A))
            {
                movePlayer(4);
            }
            playerT.rotation = camT.rotation;
        }
    }

    public void movePlayer(int directionInt)
    {
        if (directionInt == 1)
        {
            playerT.Translate(0, 0, playerMoveSpeed * Time.deltaTime);
        }
        if (directionInt == 2)
        {
            playerT.Translate(0, 0, -playerMoveSpeed * Time.deltaTime);
        }
        if (directionInt == 3)
        {
            playerT.Translate(playerMoveSpeed * Time.deltaTime, 0, 0);
        }
        if (directionInt == 4)
        {
            playerT.Translate(-playerMoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
