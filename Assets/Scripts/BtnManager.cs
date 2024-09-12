using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject NomalButton; // 노말 버튼
    public GameObject HardButton;  // 하드 버튼
    public GameObject SecretButton;
    public GameObject NomalUn;
    public GameObject HardUn;

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
            NomalUn.SetActive(false);
        }
        else
        {
            NomalButton.SetActive(false);
            Debug.Log("노말 버튼 비활성화");
            NomalUn.SetActive(true);
        }

        // 하드 버튼 활성화 (WinNomal이 1이면 하드 버튼 활성화)
        if (WinNomal == 1)
        {
            HardButton.SetActive(true);
            Debug.Log("하드 버튼 활성화");
            HardUn.SetActive(false);
        }
        else
        {
            HardButton.SetActive(false);
            Debug.Log("하드 버튼 비활성화");
            HardUn.SetActive(true);
        }
    }
    private KeyCode[] konamiCode = {
        KeyCode.UpArrow, KeyCode.UpArrow,
        KeyCode.DownArrow, KeyCode.DownArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.B, KeyCode.A
    };
    int currentInputIndex = 0;
    // Update is called once per frame
    void Update()
    {
        

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(konamiCode[currentInputIndex]))
            {
                // 올바른 키가 입력되면 다음 인덱스로
                currentInputIndex++;
                // 모든 커맨드가 성공적으로 입력되었으면 버튼 생성
                if (currentInputIndex >= konamiCode.Length)
                {
                    ActivateSecretButton();
                    currentInputIndex = 0; // 인덱스 초기화 (다시 입력 가능)
                }
            }
            else
            {
                // 잘못된 입력이 들어오면 다시 처음부터
                currentInputIndex = 0;
            }
        }
    }

    void ActivateSecretButton()
    {
        Debug.Log("코나미 커맨드 입력 완료! 비밀 버튼 활성화");        
            SecretButton.SetActive(true);
    }

}
