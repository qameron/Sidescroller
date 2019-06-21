using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float speed = 0.5f;
    public float PatrolRadius = 0.5f;

    private Transform rb;
    private Animator anim;
    private float Ptimer = 300f;
    private float EnemyBasePosition = 0f;
    private Vector3 direction = Vector3.right;
    public bool detected = false;
    private Transform player;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        EnemyBasePosition = transform.localPosition.x;
        player = FindObjectOfType<PlayerMove>().transform;
        }


    // Update is called once per frame
    void FixedUpdate () {
        rb = GetComponent<Transform>();
        Patrol(detected);
        Attack(detected);
	}

    public void Patrol (bool playerDetected)
    {
    if (!playerDetected)
        {
            if (Ptimer > 0f)
              {
                if (direction == Vector3.right)
                {
                    if ((Mathf.Abs(EnemyBasePosition) + PatrolRadius) < Mathf.Abs(rb.localPosition.x))
                    {
                        Ptimer = 300f;
                        direction *= -1;
                        Vector3 playerScale = rb.localScale;
                        playerScale.x *= -1;
                        rb.localScale = playerScale;
                    }
                    Ptimer -= 1f;
                    rb.Translate(direction * speed * Time.deltaTime);
                }
                else
                {
                    if ((Mathf.Abs(EnemyBasePosition) - PatrolRadius) > Mathf.Abs(rb.localPosition.x))
                    {
                        Ptimer = 300f;
                        direction *= -1;
                        Vector3 playerScale = rb.localScale;
                        playerScale.x *= -1;
                        rb.localScale = playerScale;
                    }
                    Ptimer -= 1f;
                    rb.Translate(direction * speed * Time.deltaTime);
                }
            }
            else
            {
                Ptimer = 300f;
                direction *= -1;
                Vector3 playerScale = rb.localScale;
                playerScale.x *= -1;
                rb.localScale = playerScale;
            }
        }
    }

    private void Attack(bool playerisseen)
    {
        if (playerisseen)
        {
            Rigidbody2D enemyrb = GetComponent<Rigidbody2D>();
            direction = enemyrb.transform.position - player.position;
            Vector3 playerScale = player.localScale;
            if ((direction.x<0 && playerScale.x>0) || (direction.x>0 && playerScale.x < 0))
            {
                player.localScale = new Vector3(playerScale.x * -1, playerScale.y, playerScale.z);
            }
            enemyrb.velocity = direction * speed * Time.deltaTime;
        }
    }

    public void Seen(float updateSpeed)
    {
        Debug.Log("DETECTED");
        detected = true;
        speed = updateSpeed;
    }

    public void Dead()
    {
        anim.SetBool("Dead", true);
    }
}
