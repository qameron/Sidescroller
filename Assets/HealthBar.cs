using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private Transform bar;
    private float health = 1f;
    private Vector3 effect;

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
        GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, Color.grey, 0.1f);
    }

    public float GetHealth()
    {
        return health;
    }

    IEnumerator HealthBarDelay()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
