using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform bar;
    private float health = 1f;

    // Use this for initialization
    void Start () {
        bar = GetComponent<HealthBar>().transform;
    }

    private void Update()
    {
        health = bar.localScale.x;
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public float GetHealth()
    {
        return health;
    }
}
