using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightSystem : MonoBehaviour {
    private GameObject enemy;
    [SerializeField]
    private readonly string enemyName = "Temp_Opponent";
    private readonly float maxDistanceLeap = 6.5f;
    private readonly float minDistanceLeap = 2.1f;
    private float attackTimer;
    private readonly float cooldownAttack = 0.5f;
    private bool attackActive = false;
    private float attackTrueTimer;
    // Use this for initialization
    void Start () {
        enemy = GameObject.Find(enemyName);
    }
	
	// Update is called once per frame
	void Update () {
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
            transform.Translate(0, 0, 8 * Time.deltaTime);
            if (attackTrueTimer > 0.15f)
            {
                attackActive = false;
                attackTrueTimer = 0;
            }
        }

    }

    private void ExectueAttack()
    {
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        if (dist < maxDistanceLeap && dist > minDistanceLeap && attackTimer > cooldownAttack)
        {
            transform.Translate(0, 0, dist / 2);
            attackTimer = 0;
        }
        else if (attackTimer > cooldownAttack)
        {
            transform.position = Vector3.Lerp(transform.position, enemy.transform.position, 10);
            attackTimer = 0;
        }
    }
}
