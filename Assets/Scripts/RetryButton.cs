using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void stage()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void easyBtn()
    {
        SceneManager.LoadScene("EasyScene");
    }
    public void NomalBtn()
    {
        SceneManager.LoadScene("NomalScene");
    }
    public void HardBtn()
    {
        SceneManager.LoadScene("HardScene");
    }

    public void OpenNomal()
    {
        // PlayerPrefs�� ������ �޼��Ǿ��ٴ� ������ ����
        PlayerPrefs.SetInt("Completedeasy", 1); // 1�� ������ �޼����� �ǹ�
        PlayerPrefs.Save(); // ����
        Debug.Log("�븻 ���� �޼�!");
    }
    public void OpenHard()
    {
        // PlayerPrefs�� ������ �޼��Ǿ��ٴ� ������ ����
        PlayerPrefs.SetInt("CompletedNomal", 1); // 1�� ������ �޼����� �ǹ�
        PlayerPrefs.Save(); // ����
        Debug.Log("�ϵ� ���� �޼�!");
    }
}
