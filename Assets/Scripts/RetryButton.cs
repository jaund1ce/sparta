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
        // PlayerPrefs에 조건이 달성되었다는 정보를 저장
        PlayerPrefs.SetInt("Completedeasy", 1); // 1은 조건이 달성됨을 의미
        PlayerPrefs.Save(); // 저장
        Debug.Log("노말 조건 달성!");
    }
    public void OpenHard()
    {
        // PlayerPrefs에 조건이 달성되었다는 정보를 저장
        PlayerPrefs.SetInt("CompletedNomal", 1); // 1은 조건이 달성됨을 의미
        PlayerPrefs.Save(); // 저장
        Debug.Log("하드 조건 달성!");
    }
}
