using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }
    
}
