using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnImage : MonoBehaviour {
    Transform enemyTransform;
    Vector3 enemyPos;
    TempCameraMovement scriptRef;

	void Start () {
        scriptRef = GameObject.Find("Main Camera").GetComponent<TempCameraMovement>();
        enemyTransform = GameObject.Find("bovenlichaam").GetComponent<Transform>();
	}
	
	void Update () {
        enemyPos = scriptRef.ObjectDistanceFromCamEdge(enemyTransform);
        transform.position =  new Vector3(enemyPos.x, enemyPos.y, enemyPos.z);
	}
}
