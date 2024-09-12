using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    //public GameObject targetObject;    // �̵���ų ������Ʈ
    private GameObject[] spawnedCards; // ������ ī�带 ������ �迭

    private Vector3[] targetPositions; // �� ī���� ��ǥ ��ġ�� ������ �迭
    private int[] arr;                 // ī�� �迭

    private GameManager gameManager;
    void Start()
    {
        // "GameManager"��� �̸��� ���� ������Ʈ�� ã�Ƽ�, �� ������Ʈ���� GameManager ������Ʈ�� �����ɴϴ�.
        GameObject gameManagerObject = GameObject.Find("GameManager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();

            if (gameManager != null)
            {
                int sv = gameManager.sv; // GameManager�� int ���� ������
                Debug.Log("GameManager���� ������ sv ��: " + sv);
                switch (sv)
                {
                    case 1:
                        CardEasy();
                        break;
                    case 2:
                        CardEasy();
                        break;
                    case 3:
                        CardHard();
                        break;
                    default:
                        CardHard();
                        break;
                }


            }
        }

    }

    void Update()
    {
        // ��� ī�带 ��ǥ ��ġ�� �̵���Ŵ
        for (int i = 0; i < spawnedCards.Length; i++)
        {
            if (spawnedCards[i] != null)
            {
                MoveCard(spawnedCards[i], targetPositions[i]);
            }
        }
    }

    void MoveCard(GameObject gogo, Vector3 targetPosition)
    {
        // ������ ������Ʈ�� ��ǥ ��ġ�� �ε巴�� �̵�
        gogo.transform.position = Vector3.MoveTowards(gogo.transform.position, targetPosition, 5f * Time.deltaTime);
    }
    void CardEasy()
    {
        // ī�� �迭 �ʱ�ȭ (�� ���ڰ� �� ����) 
        arr = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        // �迭�� �������� ����
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        // ������ ī��� ��ǥ ��ġ�� ������ �迭 ũ�� ����
        spawnedCards = new GameObject[arr.Length];
        targetPositions = new Vector3[arr.Length];

        // 4x4 �׸���� ī�� ��ġ
        for (int i = 0; i < arr.Length; i++)
        {
            GameObject go = Instantiate(card, this.transform); // ī�� ����
            spawnedCards[i] = go; // ������ ī�� �迭�� ����

            // �� ī���� �ʱ� ��ġ ����
            go.transform.position = new Vector2(-2.1f, -3.0f);
            go.GetComponent<Card>().Setting(arr[i]);

            // ��ǥ ��ġ ���
            float x1 = (i % 4) * 1.4f - 2.1f;
            float y1 = (i / 4) * 1.4f - 3.0f;
            targetPositions[i] = new Vector3(x1, y1, 1);
        }

        GameManager.Instance.cardCount = arr.Length; // ���� �Ŵ����� ī�� ���� ����
    }

    void CardHard()
    {
        // ī�� �迭 �ʱ�ȭ (�� ���ڰ� �� ����) 
        arr = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

        // �迭�� �������� ����
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        // ������ ī��� ��ǥ ��ġ�� ������ �迭 ũ�� ����
        spawnedCards = new GameObject[arr.Length];
        targetPositions = new Vector3[arr.Length];

        // 4x4 �׸���� ī�� ��ġ
        for (int i = 0; i < arr.Length; i++)
        {
            GameObject go = Instantiate(card, this.transform); // ī�� ����
            spawnedCards[i] = go; // ������ ī�� �迭�� ����

            // �� ī���� �ʱ� ��ġ ����
            go.transform.position = new Vector2(-2.1f, -3.0f);
            go.GetComponent<Card>().Setting(arr[i]);

            // ��ǥ ��ġ ���
            if(i < 16)
            {
            float x1 = (i % 4) * 1.4f - 2.1f;
            float y1 = (i / 4) * 1.4f - 4.2f;
                targetPositions[i] = new Vector3(x1, y1, 1);
            }
            if (i >= 16)
            {
                float x1 = ((i-16) % 4) * 1.4f - 2.1f;
                float y1 = ((i-16) / 4) * 1.4f + 1.3f;
                targetPositions[i] = new Vector3(x1, y1, 1);
            }
        }

        GameManager.Instance.cardCount = arr.Length; // ���� �Ŵ����� ī�� ���� ����
    }
}
