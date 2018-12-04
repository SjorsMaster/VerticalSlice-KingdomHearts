using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerPlayer : MonoBehaviour {
    private Animator playerAnim;
    private readonly string playerRun = "Running";
    private TempPlayerMovement scriptRef;
	private void Start () {
        playerAnim = GetComponent<Animator>();
        scriptRef = GameObject.Find("Temp_Player").GetComponent<TempPlayerMovement>();
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
        if (scriptRef.facingDirection == scriptRef.faces[0])
        {
        }
        else if (scriptRef.facingDirection == scriptRef.faces[1])
        {
        }
        else if (scriptRef.facingDirection == scriptRef.faces[2])
        {
        }
        else if (scriptRef.facingDirection == scriptRef.faces[3])
        {
        }

    }
}
