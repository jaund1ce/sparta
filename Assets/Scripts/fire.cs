using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = Random.Range(4f, 6f);
        transform.position = new Vector2 (x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
}
