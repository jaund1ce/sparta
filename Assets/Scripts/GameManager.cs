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

    public int cardCount = 0;
    public GameObject failTxt;
    public GameObject clearTxt;
    public AudioSource audioSource;

    public AudioClip countdown;
    public AudioClip matchclip;
    public AudioClip failclip;


    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        failTxt.SetActive(false);
        Camera.main.backgroundColor = new Color(90/255f, 90/255f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time >= 30.0f)
        {
            Time.timeScale = 0.0f;
            failTxt.SetActive(true);  
        }

        if(time >= 27.0f)
        {
            audioSource.PlayOneShot(countdown);
            Camera.main.backgroundColor = new Color(1f, 1f, 0f);
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
}
