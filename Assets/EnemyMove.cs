using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private Rigidbody2D rb;
    private float speed = 0.5f;
    private Animator anim;
    //private float rightorleft;
    private Vector2 direction = Vector2.right;
    public float PatrolRadius = 100;
    private float IdleTimer = 0;
    private float Ptimer = 0;
   // public bool FaceRight = true;
    

	// Use this for initialization
	void Start ()
    {
            anim = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update () {
        rb = GetComponent<Rigidbody2D>();
        Patrol();	
	}

    public void Patrol ()
    {

        print(Ptimer + " Ptimer");
        print(PatrolRadius + " Patrol Radius");

        if (Ptimer < PatrolRadius){
            
            
            transform.Translate(direction * speed * Time.deltaTime);
            Ptimer += 1;
            anim.SetFloat("walk", direction.x);
           // print(Ptimer);
            
        } else
        {
            Ptimer = -100;
            if (direction == Vector2.right)
            {
                direction = Vector2.left;
                Vector3 playerScale = transform.localScale;
                playerScale.x *= -1;
                transform.localScale = playerScale;
            }
            else
            {
                direction = Vector2.right;
                Vector3 playerScale = transform.localScale;
                playerScale.x *= -1;
                transform.localScale = playerScale;
            }
        }

       
         

    }

}
