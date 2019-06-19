using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

  //  [SerializeField]
    public float speed = 1f;

    private Vector2 direction;

	// Use this for initialization
	void Start () {
        direction = Vector2.right;
	}
	
	// Update is called once per frame
	void Update () {
        Move();	
	}

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
