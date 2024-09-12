using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounce : MonoBehaviour
{
    [SerializeField] [Range(500f, 2000f)] float speed = 1000f; //ball 이동속도 최소 500f ~ 최대 2000f 
    public Rigidbody2D rb;
    float xBall, yBall;
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        xBall = Random.Range(-2.0f, 2.0f);
        yBall = Random.Range(-3.0f, 1.3f);

        Vector2 dir = new Vector2(xBall, yBall).normalized;  

        rb.AddForce(dir * speed); // addforce로 direction * speed로 힘을 가함
    }
}
