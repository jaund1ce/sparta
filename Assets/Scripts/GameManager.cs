using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject Catimage;

    public int sv;

    public int cardCount = 0;
    public GameObject failTxt;
    public GameObject clearTxt;
    public GameObject ClearBtn;
    public AudioSource audioSource;

    public AudioClip countdown1;
    public AudioClip countdown2;
    public AudioClip countdown3;
    public AudioClip matchclip;
    public AudioClip failclip;
    public GameObject hammer;
    public GameObject fire;
    public GameObject spark;
    public GameObject ball;

    public GameObject transparent;//≈ı∏Ì


    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "EasyScene":
                sv = 1;
                break;
            case "NomalScene":
                sv = 2;
                InvokeRepeating("makeFire", 0f, 1f);
                InvokeRepeating("makeSpark", 1f, 3f);
                break;
            case "HardScene":
                sv = 3;
                InvokeRepeating("makeFire", 0f, 1f);
                InvokeRepeating("makeSpark", 1f, 3f);
                break;
            default:
                sv = 0;
                InvokeRepeating("makeFire", 0f, 0.5f);
                InvokeRepeating("makeSpark", 1f, 2f);
                break;
        }
        
        Debug.Log(sv);

        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        switch (sv)
        {
            case 1:
                if (time >= 60.0f)
                {
                    GameOver();
                }

                if (time >= 57.0f)
                {
                    if (time < 60f)
                    {
                        transparent.SetActive(true);
                    }
                    audioSource.PlayOneShot(countdown1);

                }
                break;
            case 2:
                if (time >= 50.0f)
                {
                    GameOver();
                }

                if (time >= 47.0f)
                {
                    if (time < 50f)
                    {
                        transparent.SetActive(true);
                    }
                    audioSource.PlayOneShot(countdown2);

                }
                break;
            case 3:
                if (time >= 40.0f)
                {
                    GameOver();
                }

                if (time >= 37.0f)
                {
                    if (time < 40f)
                    {
                        transparent.SetActive(true);
                    }
                    audioSource.PlayOneShot(countdown3);

                }
                break;
        }

        if (sv == 3 || sv == 0)
        {
            if (time >= 4f)
            {
                if (time < 8f) {
                    ShowCatimage(); 
                }
            }

            if (time >= 10f)
            {
                ball.SetActive(true);
            }
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
                ClearBtn.SetActive(true);
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

    void makeFire()
    {
        Instantiate(fire);
    }

    void ShowCatimage()
    {
        Catimage.SetActive(true);
    }

    void makeSpark()
    {
        Instantiate(spark);
    }

    void GameOver()
    {
        Time.timeScale = 0.0f;
        transparent.SetActive(false);
        Cursor.visible = true; 
        hammer.SetActive(false); 
        failTxt.SetActive(true);
    }
}
