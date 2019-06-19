using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float Speed = 10f;
    private bool FacingRight;
    private float horizontalinput;
    public float dashDistance = 5f;
    private Animator anim;
    public bool dashed = false;
    public float dashCooldown = 3f;


    void Start()
    {
        FacingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        float rightorleft = horizontalinput * Speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + rightorleft, transform.position.y);
        Flip(horizontalinput);

        if (Input.GetKeyDown("left shift") && dashed == false)
        {
            dashed = true;
            anim.SetBool("Dash", true);
            if (FacingRight == true)
            {
                transform.position = new Vector2(transform.position.x + dashDistance, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - dashDistance, transform.position.y);
            }
            StartCoroutine("WaitforDash");
        }
    }

    //Flips the player x scale if the horizontal value (direction) is not the same as the
    //player orientation
    void Flip(float horizontal)
    {
        if ((horizontal > 0.1 && !FacingRight) || (horizontal < -0.1 && FacingRight))
        {
            FacingRight = !FacingRight;

            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }

    }

    IEnumerator WaitforDash()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Dash", false);
        yield return new WaitForSeconds(dashCooldown);
        dashed = false;
    }
}
