using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnImage : MonoBehaviour {
    private Transform enemyTransform;
    private Vector3 enemyPos;
    private TempCameraMovement scriptRef;
	// Use this for initialization
	void Start () {
        scriptRef = GameObject.Find("Main Camera").GetComponent<TempCameraMovement>();
        enemyTransform = GameObject.Find("bovenlichaam").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        enemyPos = scriptRef.ObjectDistanceFromCamEdge(enemyTransform);
        transform.position =  new Vector3(enemyPos.x, enemyPos.y, enemyPos.z);
	}
}
