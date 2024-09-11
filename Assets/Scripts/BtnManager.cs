using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject NomalButton; // 노말 버튼
    public GameObject HardButton;  // 하드 버튼

    void Start()
    {
        // PlayerPrefs에서 클리어 상태 가져오기
        int WinEasy = PlayerPrefs.GetInt("Completedeasy", 0); // Easy 클리어 여부
        int WinNomal = PlayerPrefs.GetInt("CompletedNomal", 0); // Nomal 클리어 여부

        // 노말 버튼 활성화 (WinEasy가 1이면 노말 버튼 활성화)
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
            //Debug.Log("하드 버튼 활성화");
        }
        else
        {
            HardButton.SetActive(false);
            //Debug.Log("하드 버튼 비활성화");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
