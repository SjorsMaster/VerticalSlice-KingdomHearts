using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCameraMovement : MonoBehaviour {
    private Transform playerTransform;
    private Transform enemyTransform;
    private Transform cameraTransform;
    [SerializeField]
    private string playerName = "Temp_Player";
    [SerializeField]
    private string enemyName = "Temp_Opponent";
    private Camera cam;
    private float camMove;
    private bool isCentered = true;
	void Start () {
        playerTransform = GameObject.Find(playerName).GetComponent<Transform>();
        enemyTransform = GameObject.Find(enemyName).GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
        cam = GetComponent<Camera>();
	}
	
	void Update () {
        KeepPlayerInView();
    }

    private Vector3 CalculateCenter()
    {
        Vector3 result = (playerTransform.position + enemyTransform.position) / 2;
        return result;
    }

    private Vector3 ObjectDistanceFromCamEdge()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(playerTransform.position);
        return screenPos;
    }

    private void KeepPlayerInView()
    {
        if (ObjectDistanceFromCamEdge().x < 450)
        {
            camMove = -6.2f;
        }
        else if (ObjectDistanceFromCamEdge().x > 1500)
        {
            camMove = 6.2f;
        }
        else
        {
            if (ObjectDistanceFromCamEdge().x > 950 && ObjectDistanceFromCamEdge().x < 970)
            {
                isCentered = true;
            }
            else
            {
                isCentered = false;
            }
            if (ObjectDistanceFromCamEdge().x > 450 && ObjectDistanceFromCamEdge().x < 960 && !isCentered)
            {
                camMove = -3.2f;
            }
            else if (ObjectDistanceFromCamEdge().x < 1500 && ObjectDistanceFromCamEdge().x > 960 && !isCentered)
            {
                camMove = 3.2f;
            }
            else
            {
                camMove = 0;
            }
        }
        Debug.Log(ObjectDistanceFromCamEdge());
        //cameraTransform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), camRot);
        cameraTransform.Translate(camMove * Time.deltaTime, 0, 0);

    }
}
