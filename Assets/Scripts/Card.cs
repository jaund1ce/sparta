using System.Collections;
using System.Collections.Generic;
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

    Vector2 startPos;
    public Vector2 endPos;

    public float speed;
    float t = 0f;

    public AudioClip clip;
    public AudioSource audioSource;

    public Animator cardAnimator;

    void start()
    {
        startPos = transform.position;
    }

    public void Setting(int idx)
    {
        index = idx;
        frontImage.sprite = Resources.Load<Sprite>($"card{index}");

        if (index == 0 || index == 1)
        {
            endPos = GameManager.Instance.card02.transform.position;                            // new Vector3(-0.649999976f, 2.5f, 0f);
        }
        else if (index == 2 || index == 3)
        {
            endPos = GameManager.Instance.card03.transform.position;                            //new Vector3(0.649999976f, 2.5f, 0f);
        }
        else if (index == 4 || index == 5)
        {
            endPos = GameManager.Instance.card01.transform.position;                           //new Vector3(-1.95000005f, 2.5f, 0f);
        }
        else if (index == 6 || index == 7)
        {
            endPos = GameManager.Instance.card04.transform.position;                           //new Vector3(1.95000005f, 2.5f, 0f);
        }

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
        cardAnimator = GetComponent<Animator>();
        cardAnimator.enabled = false;
        transform.localScale = new Vector3(3f, 3f, 1f);
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("CardScaleDown", 0f, 0.02f);

       

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 1.3)
        {
            cardAnimator.enabled = true;
        }
        

        if (ismatched == true)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector2.Lerp(this.transform.position, endPos, t);
        }
        else
        {
            return;
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

    void CardScaleDown()
    {
        if (transform.localScale.x > 1.3)
        {
        transform.localScale -= new Vector3(0.02f, 0.02f, 0f);
        }
    }
}
