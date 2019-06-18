using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour {

    [Range(1, 10)]
    public float fallMultiplier = 2.5f;
    public float lowJumpMulitplier = 2f;
    private bool isFirstJump;
    private bool isSecondJump;
    public float jumpVelocity;

    //private Animator anim;

    Rigidbody2D playerRb;
    
    // Use this for initialization
    void Start () {
        playerRb = GetComponent<Rigidbody2D>();
        isFirstJump = false;
        isSecondJump = false;

        //anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void FixedUpdate () { 

}
    void Update ()
    {
        //jump
        if (Input.GetKeyDown("space"))
        {
            if (playerRb.velocity.y == 0 && isFirstJump == false)
            {
                isFirstJump = true;
                isSecondJump = false;
                playerRb.velocity = Vector2.up * jumpVelocity;
                //jump animator?
                }
            else if (isSecondJump == false)
            {
                playerRb.velocity = Vector2.up * jumpVelocity;
                isFirstJump = false;
                isSecondJump = true;
                //jump animator?
            }
        }

        //smoother jump mechanics w quicker fall
        if (playerRb.velocity.y < 0)
        {
            playerRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMulitplier - 1) * Time.deltaTime;
        }

        //reset jump values if on ground (fixes jumping not resetting bug)
        if (playerRb.velocity.y == 0.0)
        {
            isFirstJump = false;
            isSecondJump = false;
        }
    }
}
