using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Card : MonoBehaviour
{
    public int index = 0;

    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject back;

    public Animator anim;


    public AudioClip clip;
    public AudioSource audioSource;


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
        
    }

    void frontactive()
    {
        front.SetActive(true);
    }
 
    void backactive()
    {
        back.SetActive(false);
    }

    void playAudio()
    {
        audioSource.PlayOneShot(clip);
    }

}
