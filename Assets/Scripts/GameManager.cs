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
    public AudioClip clip;

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        //failTxt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time >= 30f)
        {
            failTxt.SetActive(true);
            Time.timeScale = 0.0f;
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
            audioSource.PlayOneShot(clip);

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
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

}
