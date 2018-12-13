using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightSystem : MonoBehaviour {
    private GameObject enemy;
    private GameObject childObjectAnim;
    private TempCameraMovement scriptRefCamera;
    [SerializeField]
    private readonly string enemyName = "Temp_Opponent";
    private readonly string childObjectName = "AnimationP";
    private readonly float maxDistanceLeap = 6.5f;
    private readonly float minDistanceLeap = 2.1f;
    private float attackTimer;
    private readonly float cooldownAttack = 0.5f;
    public bool attackActive = false;
    private float attackTrueTimer;
    [SerializeField]
    private readonly float leapDistance = 8;
    // Use this for initialization
    void Start () {
        enemy = GameObject.Find(enemyName);
        childObjectAnim = GameObject.Find(childObjectName);
        scriptRefCamera = GameObject.Find("Main Camera").GetComponent<TempCameraMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(attackActive);
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        attackTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && attackTimer > cooldownAttack && dist < maxDistanceLeap && dist > minDistanceLeap)
        {
            attackActive = true;
            attackTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && attackTimer > cooldownAttack && dist < maxDistanceLeap)
        {
            Debug.Log("Attack");
            attackTimer = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        
        if (attackActive && attackTrueTimer < 0.2f)
        {
            attackTrueTimer += Time.deltaTime;
            transform.Translate(0, 0, leapDistance * Time.deltaTime);
            childObjectAnim.transform.localEulerAngles = new Vector3(0, scriptRefCamera.transform.rotation.y, 0);
            if (attackTrueTimer > 0.15f)
            {
                attackActive = false;
                attackTrueTimer = 0;
            }
        }

    }
}
