using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]
    private HealthBar healthBar;
    private float health;
    private Animator anim;
    private BoxCollider2D enemies;
    private bool playerDamaged;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        if (healthBar == null)
        {
            Debug.Log("No healthbar found");
        }
        health = healthBar.GetHealth();
        anim = GetComponent<Animator>();
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerDamaged)
        {
            health = healthBar.GetHealth();
            if (health <= 0)
            {
                anim.SetBool("Dead", true);
            }
            else
            {
                healthBar.SetSize(health - 0.25f);
            }
            playerDamaged = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Rogue_"))
        {
            rb = GetComponent<Rigidbody2D>();

            if ((col.gameObject.transform.localScale.x < 0 && this.transform.localScale.x < 0) || (col.gameObject.transform.localScale.x > 0 && this.transform.localScale.x > 0))
            { 
                col.attachedRigidbody.velocity = (rb.velocity * 2);
                WaitforSecnds(0.2f);
                col.gameObject.GetComponent<EnemyMove>().Dead();
                WaitforSecnds(0.2f);
                Destroy(col.gameObject);
            }
            else
            {
                playerDamaged = true;
                rb.velocity = new Vector2(rb.velocity.normalized.x * -20, 5);
                //set animation
                WaitforSecnds(2f);
            }
            }
    }

    IEnumerator WaitforSecnds(float time)
    {
        yield return new WaitForSeconds(time);
    }
}