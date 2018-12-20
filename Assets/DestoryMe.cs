using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryMe : StateMachineBehaviour {

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
