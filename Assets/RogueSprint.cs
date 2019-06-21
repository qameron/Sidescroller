using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueSprint : MonoBehaviour
{

    private Vector3 playerposition;
    private Vector3 enemyposition;
    public float detectionRange = 2f;
    private Animator anim;
    public float sprintSpeed = 2f;
    private bool playerclose = false;

    // Use this for initialization
    void Start()
    {
        enemyposition = GetComponent<Transform>().position;
        playerposition = FindObjectOfType<PlayerMove>().transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerclose)
        {
            if (Vector3.Distance(playerposition, enemyposition) <= detectionRange)
            {
                anim.SetFloat("Patrolstroll", 5f);
                GetComponent<EnemyMove>().Seen(sprintSpeed);
                playerclose = true;
            }
        }
    }
}
