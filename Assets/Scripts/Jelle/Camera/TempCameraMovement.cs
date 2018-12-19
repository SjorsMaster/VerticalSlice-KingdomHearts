using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCameraMovement : MonoBehaviour {
    Transform playerTransform,
              enemyTransform,
              cameraTransform;

    [SerializeField]
    string playerName = "Temp_Player", 
           enemyName = "Temp_Opponent";

    Camera cam;
    bool isCentered = true;

    [SerializeField]
    float camDistanceFromPlayerBack = 5.6f,
          camDistanceFromPlayerFront = 7.4f,
          normalCamSpeed = 60,
          fastCamSpeed = 90,
          currentResX = Screen.width,
          currentResY = Screen.height,
          camMove;

    void Start () {
        playerTransform = GameObject.Find(playerName).GetComponent<Transform>();
        enemyTransform = GameObject.Find(enemyName).GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
        cam = GetComponent<Camera>();        
    }
	
	void Update () {
        KeepPlayerInView();
        CameraStayBehindPlayer();
        RotateTowardsLockOn();
        CheckIfBehindEnemy();
    }

    private Vector3 CalculateCenter()
    {
        Vector3 result = (playerTransform.position + enemyTransform.position) / 2;
        return result;
    }

    public Vector3 ObjectDistanceFromCamEdge(Transform tForm)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(tForm.position);
        return screenPos;
    }

    private void KeepPlayerInView()
    {
        if (ObjectDistanceFromCamEdge(playerTransform).x < currentResX / 3.49f)
        {
            camMove = -6.2f;
        }
        else if (ObjectDistanceFromCamEdge(playerTransform).x > currentResX / 1.745f)
        {
            camMove = 6.2f;
        }
        else
        {
            if (ObjectDistanceFromCamEdge(playerTransform).x > currentResX / 2.02f && ObjectDistanceFromCamEdge(playerTransform).x < currentResX / 1.97f)
            {
                isCentered = true;
            }
            else
            {
                isCentered = false;
            }
            if (ObjectDistanceFromCamEdge(playerTransform).x > currentResX / 4.26f && ObjectDistanceFromCamEdge(playerTransform).x < currentResX / 2 && !isCentered)
            {
                camMove = -3.2f;
            }
            else if (ObjectDistanceFromCamEdge(playerTransform).x < currentResX / 1.28f && ObjectDistanceFromCamEdge(playerTransform).x > currentResX / 2 && !isCentered)
            {
                camMove = 3.2f;
            }
            else
            {
                camMove = 0;
            }
        }
        cameraTransform.Translate(camMove * Time.deltaTime, 0, 0);



    }

    private void CameraStayBehindPlayer()
    {
        if (ObjectDistanceFromCamEdge(playerTransform).z < camDistanceFromPlayerBack)
        {
            transform.Translate(0, 0, -6 * Time.deltaTime);
        }
        if (ObjectDistanceFromCamEdge(playerTransform).z > camDistanceFromPlayerFront)
        {
            transform.Translate(0, 0, 6 * Time.deltaTime);

        }

        if (ObjectDistanceFromCamEdge(playerTransform).y < currentResY / 3.50f)
        {
            transform.Translate(0, -6 * Time.deltaTime, 0);
        }
        if (ObjectDistanceFromCamEdge(playerTransform).y > currentResY / 3.08f)
        {
            transform.Translate(0, 6 * Time.deltaTime, 0);
        }
      
    }

    private void RotateTowardsLockOn()
    {
        if (ObjectDistanceFromCamEdge(enemyTransform).x < currentResX / 2.26f)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0,1,0), -normalCamSpeed * Time.deltaTime);
        }
        if (ObjectDistanceFromCamEdge(enemyTransform).x > currentResX / 2.02f)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), normalCamSpeed * Time.deltaTime);
        }
        if (ObjectDistanceFromCamEdge(enemyTransform).x < currentResX / 7.68f)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), -fastCamSpeed* Time.deltaTime);
        }
        if (ObjectDistanceFromCamEdge(enemyTransform).x > currentResX / 1.28f)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), fastCamSpeed * Time.deltaTime);
        }
    }

    private void CheckIfBehindEnemy()
    {

        Vector3 relativePoint = transform.InverseTransformPoint(enemyTransform.position);
        
        if (relativePoint.z < 5 && relativePoint.x > 0.0f)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), 2.5f);
        }
        else if (relativePoint.z < 5 && relativePoint.x < 0.0f)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), -2.5f);
        }

    }

    

}
