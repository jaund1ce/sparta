using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    float time = 0.0f;

    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public GameObject card01;
    public GameObject card02;
    public GameObject card03;
    public GameObject card04;


    public int cardCount = 0;
    public GameObject failTxt;
    public GameObject clearTxt;
    public AudioSource audioSource;

    public AudioClip countdown;
    public AudioClip matchclip;
    public AudioClip failclip;
    public GameObject hammer;
    public GameObject fire; // 불 기믹
    public GameObject spark; // 스파크 기믹

    public GameObject transparent;//투명

    void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("makeFire", 0f, 1f);
        InvokeRepeating("makeSpark", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time >= 30.0f)
        {
            Time.timeScale = 0.0f;
            transparent.SetActive(false);
            Cursor.visible = true; // 마우스 커서 활성화
            hammer.SetActive(false); // 해머 오브젝트 종료
        }

        if (time >= 27.0f)
        {
            if (time < 30f)
            {
                transparent.SetActive(true);
            }
            audioSource.PlayOneShot(countdown);
            
        }

    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void checkMatched()
    {
        if (firstCard.index == secondCard.index)
        {
            Invoke("playmatch", 0.5f);

            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                Cursor.visible = true;
                clearTxt.SetActive(true);
                Time.timeScale = 0.0f;            
            }
        }
        else
        {
            Invoke("playfail", 0.5f);
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    void playfail()
    {
        audioSource.PlayOneShot(failclip);
    }

    void playmatch()
    {
        audioSource.PlayOneShot(matchclip);
    }

    void makeFire() // 불기믹생성
    {
        Instantiate(fire);
    }

    void makeSpark()
    {
        Instantiate(spark);
    }
}
