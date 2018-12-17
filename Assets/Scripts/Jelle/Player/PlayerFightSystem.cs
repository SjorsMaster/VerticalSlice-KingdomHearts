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
    private readonly float minDistanceLeap = 1.5f;
    private float attackTimer;
    private readonly float cooldownAttack = 0.3f;
    public bool attackActive = false;
    public bool attackActiveDist = false;
    private float attackTrueTimer;
    [SerializeField]
    private readonly float leapDistance = 6;
    // Use this for initialization
    void Start () {
        enemy = GameObject.Find(enemyName);
        childObjectAnim = GameObject.Find(childObjectName);
        scriptRefCamera = GameObject.Find("Main Camera").GetComponent<TempCameraMovement>();
    }

    // Update is called once per frame
    void Update() {
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
            attackActiveDist = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 0, leapDistance * Time.deltaTime);
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
