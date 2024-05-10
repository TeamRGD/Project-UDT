using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousObject : MonoBehaviour
{
    public float speed = 5.0f; // �̵� �ӵ�
    public float changeDirectionTime = 2.0f; // ���� ���� ����
    public float raycastLength = 5.0f; // ����ĳ��Ʈ ����
    public float movementRadius = 10.0f; // �ִ� �̵� �ݰ�

    private Vector3 initialPosition;
    private Vector3 moveDirection;

    void Start()
    {
        initialPosition = transform.position; // �ʱ� ��ġ ����
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

            // �ʱ� ��ġ�κ��� ������ �ݰ� �������� �̵��ϵ��� ����
            if (Vector3.Distance(newPosition, initialPosition) > movementRadius)
            {
                moveDirection = -moveDirection; // �ݰ��� ��� ���, ������ �ݴ�� ����
            }
            else
            {
                transform.position = newPosition;
            }
        }
        else
        {
            // �浹 ���� ��, ���ο� ���� ����
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
            return hit.collider.isTrigger; // Trigger�� ��츸 ��� �����ϵ���, ���� ������ ��ֹ��̸� ȸ��
        }
        return true; // ��ֹ��� ���� ��� true ��ȯ
    }
}
