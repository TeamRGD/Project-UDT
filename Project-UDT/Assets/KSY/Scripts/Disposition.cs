using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disposition : MonoBehaviour
{
    public List<GameObject> buildingPrefabs; // 건물의 Prefab을 할당받을 변수
    private GameObject currentInstance; // 현재 활성화된 인스턴스를 저장하는 변수

    void Update()
    {
        if (currentInstance != null)
        {
            // 마우스 포인터를 따라가는 로직
            Plane groundPlane = new Plane(Vector3.up, 0); // 지면 평면 생성 (y = 0인 평면임.)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0.0f;

            if (groundPlane.Raycast(ray, out enter)) // 레이와 평면의 교차점 계산
            {
                Vector3 hitPoint = ray.GetPoint(enter); // 교차 지점 계산
                currentInstance.transform.position = hitPoint; // 교차 지점으로 위치 즉시 업데이트
            }

            // 마우스 클릭으로 위치 고정
            if (Input.GetMouseButtonDown(0))
            {
                currentInstance = null; // 인스턴스 위치 고정 후 더 이상 움직이지 않도록 null 처리
            }
        }
            
    }

    // UI 버튼에 의해 호출될 메소드
    public void CreateBuildingInstance(int index)
    {
        if (index >= 0 && index < buildingPrefabs.Count)
        {
            currentInstance = Instantiate(buildingPrefabs[index]);
        }
    }

}