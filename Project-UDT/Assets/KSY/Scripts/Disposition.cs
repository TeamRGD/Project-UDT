using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Disposition : MonoBehaviour
{
    public List<GameObject> buildingPrefabs; // �ǹ��� Prefab�� �Ҵ���� ����
    private GameObject currentInstance; // ���� Ȱ��ȭ�� �ν��Ͻ��� �����ϴ� ����
    private float fixedYPosition; // ������ Y ��ġ
    private bool isPlacing = false;
    private int currentPrefabIndex = -1; // ���� ���õ� Prefab�� �ε���

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
                hitPoint.y = fixedYPosition;
                currentInstance.transform.position = hitPoint; // ���� �������� ��ġ ��� ������Ʈ
            }

            // ���콺 Ŭ������ ��ġ ����
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                currentInstance = null;
                isPlacing = false; // ��ġ �Ϸ�, ��ġ ��� ��Ȱ��ȭ
            }
        }
            
    }

    // UI ��ư�� ���� ȣ��� �޼ҵ�
    public void CreateBuildingInstance(int index)
    {
        if (isPlacing && currentInstance != null)
        {
            if (currentPrefabIndex == index)
            {
                // ���� ��ư�� ���� ���, �ν��Ͻ��� ����
                Destroy(currentInstance);
                currentInstance = null;
                isPlacing = false;
                return; // �ν��Ͻ� ���� �� �Լ� ����
            }
            else
            {
                // �ٸ� ��ư�� ���� ���, ���� �ν��Ͻ� ���� �� �� �ν��Ͻ� ����
                Destroy(currentInstance);
                currentInstance = null;
                isPlacing = false;
            }
        }

        // �� �ν��Ͻ� ����
        if (!isPlacing && index >= 0 && index < buildingPrefabs.Count)
        {
            InstantiateNewBuilding(index);
        }
    }

    private void InstantiateNewBuilding(int index)
    {
        if (index >= 0 && index < buildingPrefabs.Count)
        {
            currentInstance = Instantiate(buildingPrefabs[index]);
            // �ʱ� ��ġ ����: �ٴڿ� �굵�� ���� ����
            float buildingHeight = currentInstance.GetComponent<Renderer>().bounds.size.y;
            fixedYPosition = buildingHeight / 2; // y ��ġ�� ����
            Vector3 initialPosition = currentInstance.transform.position;
            initialPosition.y = fixedYPosition;
            currentInstance.transform.position = initialPosition;
            isPlacing = true; // ���ο� �ν��Ͻ��� �����Ǿ����Ƿ� ��ġ ��� Ȱ��ȭ
            currentPrefabIndex = index; // ���� ������ �ν��Ͻ��� �ε��� ����
        }
    }
}