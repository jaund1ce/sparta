using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject NomalButton; // �븻 ��ư
    public GameObject HardButton;  // �ϵ� ��ư

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
        }
        else
        {
            NomalButton.SetActive(false);
            Debug.Log("�븻 ��ư ��Ȱ��ȭ");
        }

        // �ϵ� ��ư Ȱ��ȭ (WinNomal�� 1�̸� �ϵ� ��ư Ȱ��ȭ)
        if (WinNomal == 1)
        {
            HardButton.SetActive(true);
            //Debug.Log("�ϵ� ��ư Ȱ��ȭ");
        }
        else
        {
            HardButton.SetActive(false);
            //Debug.Log("�ϵ� ��ư ��Ȱ��ȭ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
