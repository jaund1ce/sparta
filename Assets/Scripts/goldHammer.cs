using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldHammer : MonoBehaviour
{
    public GameObject Hammer;

    void Start() // ���� ��ġ����
    {   
        float x = 1.9f;
        float y = 2.5f; 
        transform.position = new Vector2 (x, y);       
    }

    // Update is called once per frame
    void Update() 

     
     // ���콺 �����Ϳ� ���� ��ġ�� �̵��ϰ�
     
     // ��ġ�� ����Ǵ� �ִϸ��̼��� �۵��ϰ�
     // ī�尡 ������ �ı��ȴ�
        
    {
        if(Input.GetMouseButton(0)) // ������ ��ġ�� ��ġ�� �� Ŭ����
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    void makeHammer()
    {

    }
}
