using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour {
    bool Go;
    bool InOrOut;
    string tempScene;
    string OldScene;

    public void FadeToStage(string sceneName)
    {
        tempScene = sceneName;
        Go = true;
    }

    public void FadeFromStage()
    {
        InOrOut = false;
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene(tempScene);
    }    

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != OldScene)
        {
            OldScene = SceneManager.GetActiveScene().name;
            InOrOut = true;
            FadeFromStage();
        }

        if (Go)
        {
            Image imageToFade = GetComponent<Image>();
            var imageColour = imageToFade.color;
            if (imageColour.a <= 255 && InOrOut)
            {
                imageColour.a -= 0.01f;
                imageToFade.color = imageColour;
            }
            if (imageColour.a >= 0 && !InOrOut)
            {
                imageColour.a += 0.01f;
                imageToFade.color = imageColour;
            }
        }

    }
}
