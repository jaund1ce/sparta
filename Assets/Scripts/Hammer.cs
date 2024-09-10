using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip hammerClick;

    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;


        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ����
        {
            animator.SetBool("isClick", true);
            audioSource.PlayOneShot(hammerClick);
        }
        else if (Input.GetMouseButtonUp(0)) // ���콺 Ŭ������ ������
        {
            animator.SetBool("isClick", false);
            audioSource.PlayOneShot(hammerClick);
        }

    }
    


}
