using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NomalButton;
    public GameObject HardButton;


    void Start()
    {
        int WinEasy = PlayerPrefs.GetInt("Completedeasy", 0);// 기본값은 0 (조건 미달성)
        int WinNomal = PlayerPrefs.GetInt("CompletedNomal", 0);// 기본값은 0 (조건 미달성)

        if (WinEasy == 1)
        {
            NomalButton.SetActive(true);
            Debug.Log("노말 버튼 활성화");
        }
        else
        {
            NomalButton.SetActive(false);
            Debug.Log("노말 버튼 비활성화");
        }

        // 하드 버튼 활성화 (WinNomal이 1이면 하드 버튼 활성화)
        if (WinNomal == 1)
        {
            HardButton.SetActive(true);
            Debug.Log("하드 버튼 활성화");
        }
        else
        {
            HardButton.SetActive(false);
            Debug.Log("하드 버튼 비활성화");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
