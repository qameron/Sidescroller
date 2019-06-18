using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float Speed = 10f;
    private bool FacingRight;
    private float horizontalinput;

	// Use this for initialization
	void Start () {
        FacingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        horizontalinput = Input.GetAxis("Horizontal");
        float rightorleft = horizontalinput * Speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + rightorleft, transform.position.y);
        Flip(horizontalinput);
	}

    //Flips the player x scale if the horizontal value (direction) is not the same as the 
    //player orientation
    void Flip(float horizontal)
    {
        if((horizontal > 0.1 && !FacingRight) || (horizontal < -0.1 && FacingRight))
        {
            FacingRight = !FacingRight;

            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
