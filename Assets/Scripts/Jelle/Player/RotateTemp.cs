using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTemp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        var a = Mathf.Atan2(x, y);
        print(a);
        transform.localEulerAngles = new Vector3(a * 360, 0,0);
	}
}
