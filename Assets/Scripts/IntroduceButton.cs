using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroduceButton : MonoBehaviour


{
    public GameObject Introduce;



    public void Intro()
    {
        Introduce.SetActive(true);
    }
   
    public void Outro() 
    {    
        Introduce.SetActive(false); 
    }
}

