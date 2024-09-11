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
        int WinEasy = PlayerPrefs.GetInt("Completedeasy", 0);// �⺻���� 0 (���� �̴޼�)
        int WinNomal = PlayerPrefs.GetInt("CompletedNomal", 0);// �⺻���� 0 (���� �̴޼�)

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
            Debug.Log("�ϵ� ��ư Ȱ��ȭ");
        }
        else
        {
            HardButton.SetActive(false);
            Debug.Log("�ϵ� ��ư ��Ȱ��ȭ");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
