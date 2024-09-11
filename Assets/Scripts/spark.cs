using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spark : MonoBehaviour
{
    public float delay = 3.0f;
    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = Random.Range(-3.0f, 1.3f);
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, delay);
    }
}
