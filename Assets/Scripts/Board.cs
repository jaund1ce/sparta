using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    public GameObject targetObject;    // 이동시킬 오브젝트
    private GameObject[] spawnedCards; // 생성된 카드를 저장할 배열

    private Vector3[] targetPositions; // 각 카드의 목표 위치를 저장할 배열
    private int[] arr;                 // 카드 배열

    void Start()
    {
        // 카드 배열 초기화 (각 숫자가 두 개씩)
        arr = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        // 배열을 랜덤으로 섞음
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        // 생성된 카드와 목표 위치를 저장할 배열 크기 설정
        spawnedCards = new GameObject[arr.Length];
        targetPositions = new Vector3[arr.Length];

        // 4x4 그리드로 카드 배치
        for (int i = 0; i < arr.Length; i++)
        {
            GameObject go = Instantiate(card, this.transform); // 카드 생성
            spawnedCards[i] = go; // 생성된 카드 배열에 저장

            // 각 카드의 초기 위치 설정
            go.transform.position = new Vector2(-2.1f, -3.0f);
            go.GetComponent<Card>().Setting(arr[i]);

            // 목표 위치 계산
            float x1 = (i % 4) * 1.4f - 2.1f;
            float y1 = (i / 4) * 1.4f - 3.0f;
            targetPositions[i] = new Vector3(x1, y1, 1);
        }

        GameManager.Instance.cardCount = arr.Length; // 게임 매니저에 카드 개수 설정
    }

    void Update()
    {
        // 모든 카드를 목표 위치로 이동시킴
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
        // 생성된 오브젝트가 목표 위치로 부드럽게 이동
        gogo.transform.position = Vector3.MoveTowards(gogo.transform.position, targetPosition, 5f * Time.deltaTime);
    }

}
