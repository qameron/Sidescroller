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

    // Use this for initialization
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        if (healthBar == null)
        {
            Debug.Log("No healthbar found");
        }
        health = healthBar.GetHealth();
        //set animator
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerDamaged)
        {
            Debug.Log(health);
            health = healthBar.GetHealth();
            if (health <= 0)
            {
                //need to add bool in animator
                //anim.SetBool("Dead", true);
            }
            else
            {
                healthBar.SetSize(health - 0.25f);
            }
            playerDamaged = false;
        }
    }

    //wont enter?
    void OnTriggerEnter2D(Collider2D col)
    {
            Debug.Log("collided");
            if (col.gameObject.name.Contains("Rogue_"))
            {
                playerDamaged = true;
                //set animation
                //wait 2s
                Destroy(col.gameObject);
            }
    }
}