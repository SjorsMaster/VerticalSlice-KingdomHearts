


using UnityEngine;

public class TempPlayerMovement : MonoBehaviour {
    Transform playerT,
              camT;
    Vector3 oldpos;
    float playerMoveSpeed;
    PlayerFightSystem scriptRefFight;
    Animator anim;

	void Start () {
        anim = GetComponent<Animator>(); 
        playerT = GetComponent<Transform>();
        camT = GameObject.Find("Main Camera").GetComponent<Transform>();
        scriptRefFight = GetComponent<PlayerFightSystem>();
        playerMoveSpeed = 6.7f;
	}

	void Update () {
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
            if (Input.GetKey(KeyCode.K))
            {
                anim.SetTrigger("kys");
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("run", false);
            }
            if (!scriptRefFight.attackActive || !scriptRefFight.attackActiveDist) {
                playerT.rotation = camT.rotation;
            }
        }
    }

    public void movePlayer(int directionInt)
    {
        if((playerT.transform.position.z > -60 && playerT.transform.position.z < -37) && (playerT.transform.position.x > 40 && playerT.transform.position.x < 60))
        {
            oldpos = playerT.position;
            if (directionInt == 1)
            {
                playerT.Translate(0, 0, playerMoveSpeed * Time.deltaTime);
                MoveMeBabehhh();
            }
            if (directionInt == 2)
            {
                playerT.Translate(0, 0, -playerMoveSpeed * Time.deltaTime);
                MoveMeBabehhh();
            }
            if (directionInt == 3)
            {
                playerT.Translate(playerMoveSpeed * Time.deltaTime, 0, 0);
                MoveMeBabehhh();
            }
            if (directionInt == 4)
            {
                playerT.Translate(-playerMoveSpeed * Time.deltaTime, 0, 0);
                MoveMeBabehhh();
            }
        }
        else
        {
            playerT.position = oldpos;
        }
        
    }

    void MoveMeBabehhh()
    {
        anim.SetBool("run", true);
    }
}
