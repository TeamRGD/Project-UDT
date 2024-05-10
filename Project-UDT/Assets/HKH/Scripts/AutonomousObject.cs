using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousObject : MonoBehaviour
{
    public float speed = 5.0f; // 이동 속도
    public float changeDirectionTime = 2.0f; // 방향 변경 간격
    public float raycastLength = 5.0f; // 레이캐스트 길이
    public float movementRadius = 10.0f; // 최대 이동 반경

    private Vector3 initialPosition;
    private Vector3 moveDirection;

    void Start()
    {
        initialPosition = transform.position; // 초기 위치 저장
        StartCoroutine(ChangeDirectionRoutine());
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (IsPathClear())
        {
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

            // 초기 위치로부터 설정된 반경 내에서만 이동하도록 제한
            if (Vector3.Distance(newPosition, initialPosition) > movementRadius)
            {
                moveDirection = -moveDirection; // 반경을 벗어난 경우, 방향을 반대로 변경
            }
            else
            {
                transform.position = newPosition;
                // 오브젝트가 이동 방향을 바라보도록 회전
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 20.0f);
            }
        }
        else
        {
            // 충돌 예상 시, 새로운 방향 설정
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }
    }


    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            yield return new WaitForSeconds(changeDirectionTime);
        }
    }

    bool IsPathClear()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, raycastLength))
        {
            return hit.collider.isTrigger; // Trigger인 경우만 통과 가능하도록, 실제 물리적 장애물이면 회피
        }
        return true; // 장애물이 없는 경우 true 반환
    }
}
