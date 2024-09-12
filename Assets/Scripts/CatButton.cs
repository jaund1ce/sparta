using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatButton : MonoBehaviour
{
    public GameObject CatImage;  // UI �̹��� ������Ʈ
    private RectTransform catRectTransform;  // UI�� ũ�⸦ �����ϱ� ���� ���
    public Button catButton;  // ��ư ������Ʈ ����

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
    void ShrinkCatImage()
    {
        if (catRectTransform != null)
        {
            // ���� ũ�⿡ 0.9��ŭ ���� ũ�⸦ ���Դϴ�.
            catRectTransform.sizeDelta = catRectTransform.sizeDelta * 0.9f;
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

