using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldHammer : MonoBehaviour
{
    public GameObject Hammer;

    void Start() // 최초 위치생성
    {   
        float x = 1.9f;
        float y = 2.5f; 
        transform.position = new Vector2 (x, y);       
    }

    // Update is called once per frame
    void Update() 

     
     // 마우스 포인터에 따라 망치가 이동하고
     
     // 망치가 실행되는 애니메이션이 작동하고
     // 카드가 무조건 파괴된다
        
    {
        if(Input.GetMouseButton(0)) // 생성된 위치에 망치를 좌 클릭시
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    void makeHammer()
    {

    }
}
