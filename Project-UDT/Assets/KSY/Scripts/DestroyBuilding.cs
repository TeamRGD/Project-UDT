using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public bool isRemovalMode = false; // 제거 모드 상태를 추적하는 변수

    void Update()
    {
        // 마우스 클릭을 감지하고 제거 모드가 활성화되어 있으면
        if (Input.GetMouseButtonDown(0) && isRemovalMode)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 레이캐스트를 사용해 클릭된 오브젝트를 감지
            if (Physics.Raycast(ray, out hit))
            {
                // 클릭된 오브젝트가 건물인지 확인 (예를 들어 Tag를 사용)
                if (hit.collider.CompareTag("Building"))
                {
                    Destroy(hit.collider.gameObject); // 건물 제거
                }
            }
        }
        if (isRemovalMode)
        {
            Debug.Log("Remove mode");
        }
    }

    // 제거 버튼에 연결될 메소드
    public void EnableRemovalMode()
    {
        isRemovalMode = !isRemovalMode; // 제거 모드 활성화 및 비활성화
    }
}