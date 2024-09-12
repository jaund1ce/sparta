using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject NomalButton; // �븻 ��ư
    public GameObject HardButton;  // �ϵ� ��ư
    public GameObject SecretButton;
    public GameObject NomalUn;
    public GameObject HardUn;

    void Start()
    {
        // PlayerPrefs���� Ŭ���� ���� ��������
        int WinEasy = PlayerPrefs.GetInt("Completedeasy", 0); // Easy Ŭ���� ����
        int WinNomal = PlayerPrefs.GetInt("CompletedNomal", 0); // Nomal Ŭ���� ����

        // �븻 ��ư Ȱ��ȭ (WinEasy�� 1�̸� �븻 ��ư Ȱ��ȭ)
        if (WinEasy == 1)
        {
            NomalButton.SetActive(true);
            Debug.Log("�븻 ��ư Ȱ��ȭ");
            NomalUn.SetActive(false);
        }
        else
        {
            NomalButton.SetActive(false);
            Debug.Log("�븻 ��ư ��Ȱ��ȭ");
            NomalUn.SetActive(true);
        }

        // �ϵ� ��ư Ȱ��ȭ (WinNomal�� 1�̸� �ϵ� ��ư Ȱ��ȭ)
        if (WinNomal == 1)
        {
            HardButton.SetActive(true);
            Debug.Log("�ϵ� ��ư Ȱ��ȭ");
            HardUn.SetActive(false);
        }
        else
        {
            HardButton.SetActive(false);
            Debug.Log("�ϵ� ��ư ��Ȱ��ȭ");
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
                // �ùٸ� Ű�� �ԷµǸ� ���� �ε�����
                currentInputIndex++;
                // ��� Ŀ�ǵ尡 ���������� �ԷµǾ����� ��ư ����
                if (currentInputIndex >= konamiCode.Length)
                {
                    ActivateSecretButton();
                    currentInputIndex = 0; // �ε��� �ʱ�ȭ (�ٽ� �Է� ����)
                }
            }
            else
            {
                // �߸��� �Է��� ������ �ٽ� ó������
                currentInputIndex = 0;
            }
        }
    }

    void ActivateSecretButton()
    {
        Debug.Log("�ڳ��� Ŀ�ǵ� �Է� �Ϸ�! ��� ��ư Ȱ��ȭ");        
            SecretButton.SetActive(true);
    }

}
