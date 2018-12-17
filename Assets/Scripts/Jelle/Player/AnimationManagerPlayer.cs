using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerPlayer : MonoBehaviour {
    private Animator playerAnim;
    private readonly string playerRun = "Running";
    private TempPlayerMovement scriptRef;
    private TempCameraMovement scriptRefCamera;
    private PlayerFightSystem scriptRefFight;
    private void Start () {
        playerAnim = GetComponent<Animator>();
        scriptRef = GameObject.Find("Temp_Player").GetComponent<TempPlayerMovement>();
        scriptRefCamera = GameObject.Find("Main Camera").GetComponent<TempCameraMovement>();
        scriptRefFight = GameObject.Find("Temp_Player").GetComponent<PlayerFightSystem>();
    }
	
	private void Update () {
        RotateAnimation();
        PlayerRun();
	}

    private void PlayerRun()
    {
        playerAnim.Play(playerRun);
    }

    private void RotateAnimation()
    {
        if (!scriptRefFight.attackActive)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, scriptRefCamera.transform.rotation.y - 90, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, scriptRefCamera.transform.rotation.y + 90, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.localEulerAngles = new Vector3(0, scriptRefCamera.transform.rotation.y, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.localEulerAngles = new Vector3(0, scriptRefCamera.transform.rotation.y - 180, 0);
            }
        }

    }
}
