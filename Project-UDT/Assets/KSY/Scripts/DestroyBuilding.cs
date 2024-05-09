using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public bool isRemovalMode = false; // ���� ��� ���¸� �����ϴ� ����

    void Update()
    {
        // ���콺 Ŭ���� �����ϰ� ���� ��尡 Ȱ��ȭ�Ǿ� ������
        if (Input.GetMouseButtonDown(0) && isRemovalMode)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ����ĳ��Ʈ�� ����� Ŭ���� ������Ʈ�� ����
            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� �ǹ����� Ȯ�� (���� ��� Tag�� ���)
                if (hit.collider.CompareTag("Building"))
                {
                    Destroy(hit.collider.gameObject); // �ǹ� ����
                }
            }
        }
        if (isRemovalMode)
        {
            Debug.Log("Remove mode");
        }
    }

    // ���� ��ư�� ����� �޼ҵ�
    public void EnableRemovalMode()
    {
        isRemovalMode = !isRemovalMode; // ���� ��� Ȱ��ȭ �� ��Ȱ��ȭ
    }
}