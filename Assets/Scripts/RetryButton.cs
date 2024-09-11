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

    public void ClearEasy()
    {
        PlayerPrefs.SetInt("Completedeasy", 1);
        PlayerPrefs.Save();
        Debug.Log("노말 조건 달성");
    }
    public void ClearNomal()
    {
        PlayerPrefs.SetInt("CompletedNomal", 1);
        PlayerPrefs.Save();
        Debug.Log("하드 조건 달성");
    }
}
