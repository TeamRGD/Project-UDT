using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disposition : MonoBehaviour
{
    public List<GameObject> buildingPrefabs; // �ǹ��� Prefab�� �Ҵ���� ����
    private GameObject currentInstance; // ���� Ȱ��ȭ�� �ν��Ͻ��� �����ϴ� ����

    void Update()
    {
        if (currentInstance != null)
        {
            // ���콺 �����͸� ���󰡴� ����
            Plane groundPlane = new Plane(Vector3.up, 0); // ���� ��� ���� (y = 0�� �����.)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0.0f;

            if (groundPlane.Raycast(ray, out enter)) // ���̿� ����� ������ ���
            {
                Vector3 hitPoint = ray.GetPoint(enter); // ���� ���� ���
                currentInstance.transform.position = hitPoint; // ���� �������� ��ġ ��� ������Ʈ
            }

            // ���콺 Ŭ������ ��ġ ����
            if (Input.GetMouseButtonDown(0))
            {
                currentInstance = null; // �ν��Ͻ� ��ġ ���� �� �� �̻� �������� �ʵ��� null ó��
            }
        }
            
    }

    // UI ��ư�� ���� ȣ��� �޼ҵ�
    public void CreateBuildingInstance(int index)
    {
        if (index >= 0 && index < buildingPrefabs.Count)
        {
            currentInstance = Instantiate(buildingPrefabs[index]);
        }
    }

}