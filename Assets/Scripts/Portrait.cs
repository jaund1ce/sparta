using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portrait : MonoBehaviour
{
    public Animator anim;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Card"))
        {
            anim.SetTrigger("Happy");
        }
        else
        {
            return;
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        anim.SetBool("isHappy", false);
    }



}
