using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatButton : MonoBehaviour
{
    public GameObject CatImage;  // UI 이미지 오브젝트
    private RectTransform catRectTransform;  // UI의 크기를 조절하기 위해 사용
    public Button catButton;  // 버튼 컴포넌트 연결
    public float shrinkFactor = 0.9f;  // 이미지 크기를 줄일 비율

    float catTime = 0;
    void Start()
    {
        // CatImage 활성화
        CatImage.SetActive(true);

        // CatImage의 RectTransform 컴포넌트를 가져옵니다.
        catRectTransform = CatImage.GetComponent<RectTransform>();

        // 버튼에 클릭 이벤트 연결
        catButton.onClick.AddListener(ShrinkCatImage);
    }

    // 클릭 시 이미지 크기를 줄이는 함수
    private void Update()
    {
        CatImage.SetActive(true);
    }
    void ShrinkCatImage()
    {
        catTime = Time.deltaTime;
        if (catRectTransform != null)
        {
            // 현재 크기에 shrinkFactor만큼 곱해 크기를 줄입니다.
            catRectTransform.sizeDelta = catRectTransform.sizeDelta * shrinkFactor;
        }

    }
    public void CatImageTrrigerOn()
    {
        CatImage.SetActive(true);

    }
    public void CatImageTrrigerOff()
    {
        CatImage.SetActive(false);

    }
}

