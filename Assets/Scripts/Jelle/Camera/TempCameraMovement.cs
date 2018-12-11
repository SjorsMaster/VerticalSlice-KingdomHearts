using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCameraMovement : MonoBehaviour {
    private Transform playerTransform;
    private Transform enemyTransform;
    private Transform cameraTransform;
    [SerializeField]
    private string playerName = "Temp_Player", 
                   enemyName = "Temp_Opponent";
    private Camera cam;
    private float camMove;
    private bool isCentered = true;
    [SerializeField]
    private float camDistanceFromPlayerBack = 5.6f;
    private float camDistanceFromPlayerFront = 7.4f;
    private float normalCamSpeed = 60;
    private float fastCamSpeed = 90;
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
        if (ObjectDistanceFromCamEdge(playerTransform).x < 550)
        {
            camMove = -6.2f;
        }
        else if (ObjectDistanceFromCamEdge(playerTransform).x > 1100)
        {
            camMove = 6.2f;
        }
        else
        {
            if (ObjectDistanceFromCamEdge(playerTransform).x > 950 && ObjectDistanceFromCamEdge(playerTransform).x < 970)
            {
                isCentered = true;
            }
            else
            {
                isCentered = false;
            }
            if (ObjectDistanceFromCamEdge(playerTransform).x > 450 && ObjectDistanceFromCamEdge(playerTransform).x < 960 && !isCentered)
            {
                camMove = -3.2f;
            }
            else if (ObjectDistanceFromCamEdge(playerTransform).x < 1500 && ObjectDistanceFromCamEdge(playerTransform).x > 960 && !isCentered)
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

        if (ObjectDistanceFromCamEdge(playerTransform).y < 500)
        {
            transform.Translate(0, -6 * Time.deltaTime, 0);
        }
        if (ObjectDistanceFromCamEdge(playerTransform).y > 550)
        {
            transform.Translate(0, 6 * Time.deltaTime, 0);
        }
      
    }

    private void RotateTowardsLockOn()
    {
        if (ObjectDistanceFromCamEdge(enemyTransform).x < 850)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0,1,0), -normalCamSpeed * Time.deltaTime);
        }
        if (ObjectDistanceFromCamEdge(enemyTransform).x > 950)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), normalCamSpeed * Time.deltaTime);
        }
        if (ObjectDistanceFromCamEdge(enemyTransform).x < 250)
        {
            transform.RotateAround(CalculateCenter(), new Vector3(0, 1, 0), -fastCamSpeed* Time.deltaTime);
        }
        if (ObjectDistanceFromCamEdge(enemyTransform).x > 1500)
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
