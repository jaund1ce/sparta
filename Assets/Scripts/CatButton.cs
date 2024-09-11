using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatButton : MonoBehaviour
{
    public GameObject CatImage;  // UI �̹��� ������Ʈ
    private RectTransform catRectTransform;  // UI�� ũ�⸦ �����ϱ� ���� ���
    public Button catButton;  // ��ư ������Ʈ ����
    public float shrinkFactor = 0.9f;  // �̹��� ũ�⸦ ���� ����

    float catTime = 0;
    void Start()
    {
        // CatImage Ȱ��ȭ
        CatImage.SetActive(true);

        // CatImage�� RectTransform ������Ʈ�� �����ɴϴ�.
        catRectTransform = CatImage.GetComponent<RectTransform>();

        // ��ư�� Ŭ�� �̺�Ʈ ����
        catButton.onClick.AddListener(ShrinkCatImage);
    }

    // Ŭ�� �� �̹��� ũ�⸦ ���̴� �Լ�
    private void Update()
    {
        CatImage.SetActive(true);
    }
    void ShrinkCatImage()
    {
        catTime = Time.deltaTime;
        if (catRectTransform != null)
        {
            // ���� ũ�⿡ shrinkFactor��ŭ ���� ũ�⸦ ���Դϴ�.
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

