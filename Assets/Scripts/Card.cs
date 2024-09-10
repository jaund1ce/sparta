using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Card : MonoBehaviour
{
    
    bool ismatched = false;

    public int index = 0;

    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject back;

    public Animator anim;


    public AudioClip clip;
    public AudioSource audioSource;

    Vector3 startPos;
    public Vector3 endPos;

    void start()
    {
        startPos = transform.position;
    }
    public void Setting(int idx)
    {
        index = idx;
        frontImage.sprite = Resources.Load<Sprite>($"card{index}");

    }
    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        Invoke("frontactive", 0.4f);
        Invoke("backactive", 0.4f);


        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.checkMatched();
        }
    }

    public void DestroyCard()
     {
        ismatched = true;
		Invoke("DestoryCardInvoke", 1f);
     }

    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0 && index == 1)
        {
            endPos = new Vector3(-0.649999976f, 2.5f, 0f);
        }
        else if (index == 2 && index == 3)
        {
            endPos = new Vector3(0.649999976f, 2.5f, 0f);
        }
        else if (index == 4 && index == 5)
        {
            endPos = new Vector3(-1.95000005f, 2.5f, 0f);
        }
        else if (index == 6 && index == 7)
        {
            endPos = new Vector3(1.95000005f, 2.5f, 0f);
        }

        if (ismatched == true)
        {
            

            transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime);

        }
    }

    void frontactive()
    {
        front.SetActive(true);
    }
 
    void backactive()
    {
        back.SetActive(false);
    }

    void movewhere()
    {
        
    }

}
