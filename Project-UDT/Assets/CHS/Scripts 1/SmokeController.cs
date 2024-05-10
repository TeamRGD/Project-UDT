using System.Collections;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    public GameObject[] smokeObjects; // 연기 오브젝트 배열
    public float delayBetweenSmokes = 1f; // 각 연기 사이의 시간차
    public float disappearTime = 3f; // 연기가 사라지기까지의 시간
    public Vector3 moveDirectionY = new Vector3(0, 1, 0); // y축 방향 이동
    public Vector3 moveDirectionYZ = new Vector3(0, 1, 1); // y축과 z축 방향 이동
    public float moveDistance = 1f; // 이동 거리

    private void Start()
    {
        StartCoroutine(SpawnAndMoveSmokes());
    }

    IEnumerator SpawnAndMoveSmokes()
    {
        foreach (GameObject smoke in smokeObjects)
        {
            StartCoroutine(MoveAndDisappear(smoke));
            yield return new WaitForSeconds(delayBetweenSmokes); // 다음 연기가 시작되기까지 기다림
        }
    }

    IEnumerator MoveAndDisappear(GameObject smoke)
    {
        // 초기 위치 저장
        Vector3 originalPosition = smoke.transform.position;

        // y축으로 1초 동안 이동
        float elapsedTime = 0;
        while (elapsedTime < 1f)
        {
            smoke.transform.position += moveDirectionY * moveDistance * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // y축과 z축 방향으로 이동
        elapsedTime = 0;
        while (elapsedTime < disappearTime - 1f) // 이미 1초가 지남
        {
            smoke.transform.position += moveDirectionYZ * moveDistance * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 연기 사라짐
        smoke.SetActive(false);
        yield return new WaitForSeconds(1f); // 사라지는 효과를 위해 잠시 대기

        // 초기 위치에서 다시 활성화
        smoke.transform.position = originalPosition;
        smoke.SetActive(true);

        // 다시 반복
        StartCoroutine(MoveAndDisappear(smoke));
    }
}
