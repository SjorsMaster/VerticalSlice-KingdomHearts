using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightSystem : MonoBehaviour {
    GameObject enemy,
               childObjectAnim,
               ballObject;

    TempCameraMovement scriptRefCamera;
	ThrowBall ballScriptRef;

    string enemyName = "Temp_Opponent",
           childObjectName = "AnimationP",
           ballObjectName = "Ball(Placeholder)(Clone)";

    float maxDistanceLeap = 6.5f,
          minDistanceLeap = 1.5f,
          cooldownAttack = 0.3f,
          attackTimer,
          attackTrueTimer,
          leapDistance = 6;

    public bool attackActive = false,
                attackActiveDist = false;

	bool hitBall = false;

    void Start () {
        enemy = GameObject.Find(enemyName);
        childObjectAnim = GameObject.Find(childObjectName);
        scriptRefCamera = GameObject.Find("Main Camera").GetComponent<TempCameraMovement>();
    }

    void Update() {
		if (GameObject.Find (ballObjectName) != null) {
			ballObject = GameObject.Find (ballObjectName);
            ballScriptRef = ballObject.GetComponent<ThrowBall>();
            print ("Ball Exists");
			float distBallPlayer = Vector3.Distance (ballObject.transform.position, transform.position);
			if (distBallPlayer < 5) {
				hitBall = true;
			} else {
				hitBall = false;
			}
		}
		else {
			hitBall = false;
		}

        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        attackTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && attackTimer > cooldownAttack && dist < maxDistanceLeap && dist > minDistanceLeap)
        {

            attackActive = true;
            attackTimer = 0;
			if (hitBall) {
				ballScriptRef.ThrowBack();
				hitBall = false;
			}
        }
        else if (Input.GetKeyDown(KeyCode.Space) && attackTimer > cooldownAttack && dist < maxDistanceLeap)
        {
            Debug.Log("Attack");
            attackTimer = 0;
            attackActiveDist = true;
			if (hitBall) {
				ballScriptRef.ThrowBack();
				hitBall = false;
			}
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 0, leapDistance * Time.deltaTime);
			if (hitBall) {
				ballScriptRef.ThrowBack();
				hitBall = false;
			}
        } 
       
        
        if (attackActive)
        {
            attackTrueTimer += Time.deltaTime;
            childObjectAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.LookAt(enemy.transform);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.Translate(0, 0, leapDistance * Time.deltaTime);
            if (attackTrueTimer > 0.3f)
            {
                attackActive = false;
                attackTrueTimer = 0;
            }
        }
        else if (attackActiveDist)
        {
            childObjectAnim.transform.localEulerAngles = new Vector3(0, scriptRefCamera.transform.rotation.y, 0);
            attackTrueTimer += Time.deltaTime;
            if (attackTrueTimer > 0.3f)
            {
                attackActiveDist = false;
                attackTrueTimer = 0;
            }
        } 

    }
}
