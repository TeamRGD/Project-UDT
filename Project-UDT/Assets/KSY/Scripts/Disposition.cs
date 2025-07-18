using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Disposition : MonoBehaviour
{
    public List<GameObject> buildingPrefabs; // 건물의 Prefab을 할당받을 변수
    public GameObject currentInstance; // 현재 활성화된 인스턴스를 저장하는 변수
    private float fixedYPosition; // 고정된 Y 위치
    public bool isPlacing = false;
    private int currentPrefabIndex = -1; // 현재 선택된 Prefab의 인덱스
    public float gridScale = 0.5f;
    private bool canPlacing = true;
    public bool removeMode = false;

    void Update()
    {
        if (isPlacing && currentInstance != null)
        {
            currentInstance.GetComponent<ObjectDetection>().isPlaced = false;
            // 마우스 포인터를 따라가는 로직
            Plane groundPlane = new Plane(Vector3.up, 0); // 지면 평면 생성 (y = 0인 평면임.)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0.0f;

            if (groundPlane.Raycast(ray, out enter)) // 레이와 평면의 교차점 계산
            {
                Vector3 hitPoint = ray.GetPoint(enter); // 교차 지점 계산
                hitPoint.x = RoundToGridSize(hitPoint.x);
                hitPoint.z = RoundToGridSize(hitPoint.z);
                hitPoint.y = fixedYPosition;
                currentInstance.transform.position = hitPoint; // 교차 지점으로 위치 즉시 업데이트
            }

            // 마우스 클릭으로 위치 고정
            if (canPlacing && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                SetPlane("inactive");
                currentInstance.GetComponent<ObjectDetection>().isPlaced = true;
                currentInstance = null;
                isPlacing = false; // 배치 완료, 배치 모드 비활성화
            }

            // Q 키를 눌러 시계 방향으로 90도 회전
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentInstance.transform.Rotate(0, 90, 0);
            }

            // E 키를 눌러 반시계 방향으로 90도 회전
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentInstance.transform.Rotate(0, -90, 0);
            }
        }
            
    }

    // UI 버튼에 의해 호출될 메소드
    public void CreateBuildingInstance(int index)
    {
        Debug.Log("col");
        if (isPlacing && currentInstance != null)
        {
            if (currentPrefabIndex == index)
            {
                // 같은 버튼을 누른 경우, 인스턴스만 삭제
                Destroy(currentInstance);
                currentInstance = null;
                isPlacing = false;
                return; // 인스턴스 삭제 후 함수 종료
            }
            else
            {
                // 다른 버튼을 누른 경우, 현재 인스턴스 삭제 후 새 인스턴스 생성
                Destroy(currentInstance);
                currentInstance = null;
                isPlacing = false;
            }
        }

        // 새 인스턴스 생성
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
            
            fixedYPosition = 0f; // y 위치를 고정
            Vector3 initialPosition = currentInstance.transform.position;
            initialPosition.y = fixedYPosition;
            currentInstance.transform.position = initialPosition;
            isPlacing = true; // 새로운 인스턴스가 생성되었으므로 배치 모드 활성화
            currentPrefabIndex = index; // 현재 생성된 인스턴스의 인덱스 저장
        }
    }

    float RoundToGridSize(float coordinate)
    {
        return Mathf.Round(coordinate / gridScale) * gridScale;
    }

    public void SetPlacing(bool can_placing)
    {

        if(can_placing)
            canPlacing = true;
        else
            canPlacing = false;
    }

    public bool CheckPlacing()
    {
        return canPlacing;
    }

    public void SetPlane(string color_type)
    {
        if (color_type == "gray")
        {
            currentInstance.GetComponent<LineRenderer>().material.color = Color.gray;
        }
        else if (color_type == "red")
        {
            currentInstance.GetComponent<LineRenderer>().material.color = Color.red;
        }
        else if (color_type == "green")
        {
            currentInstance.GetComponent<LineRenderer>().material.color = Color.green;
        }
        else if (color_type == "inactive")
        {
            SetPlane("gray");
            currentInstance.GetComponent<PlaneBorder>().enabled = false;
            currentInstance.transform.Find("Plane").gameObject.SetActive(false);
        }
    }

}