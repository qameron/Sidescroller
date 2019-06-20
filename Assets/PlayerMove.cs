using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public for development. Make private once fields values are finalized
    public float Speed = 10f;
    public float dashSpeed = 5f;
    public bool dashed = false;
    public float dashCooldown = 3f;
    public float dashDuration = 0.2f;
    public GameObject dashEffectPrefab;

    private float horizontalinput;
    private bool FacingRight;
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject ps;
    private Component[] childrenpsr;

    void Start()
    {
        FacingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        horizontalinput = Input.GetAxis("Horizontal");
        float rightorleft = horizontalinput * Speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + rightorleft, transform.position.y);
        Flip(horizontalinput);

        if (Input.GetKeyDown("left shift") && dashed == false)
        {
            dashed = true;
            anim.SetBool("Dash", true);
            ps = Instantiate(dashEffectPrefab, rb.transform.position, Quaternion.identity);
            childrenpsr = ps.GetComponentsInChildren<ParticleSystemRenderer>();
            foreach(ParticleSystemRenderer psr in childrenpsr)
            {
                psr.sortingOrder = 30;
            }
            if (FacingRight == true)
            {
                rb.velocity = Vector2.right * dashSpeed;
            }
            else
            {
                rb.velocity = Vector2.left * dashSpeed;
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
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = new Vector2(0, rb.velocity.y);
        Destroy(ps);
        yield return new WaitForSeconds(dashCooldown);
        dashed = false;
        }
}
