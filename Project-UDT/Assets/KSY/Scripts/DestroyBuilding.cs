using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public bool isRemovalMode = false; // 제거 모드 상태를 추적하는 변수
    public Disposition dispositionScript;
    private GameObject plane;
    private ChangeRenderingMode changeRenderingMode;
    private Material material_;
    new private Renderer renderer;


    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // 클릭된 오브젝트가 건물인지 확인 (예를 들어 Tag를 사용)
            if (hit.collider.CompareTag("Building") && isRemovalMode)
            {
                //changeRenderingMode = hit.collider.gameObject.GetComponent<ChangeRenderingMode>();
                //changeRenderingMode.isRemoveMode = isRemovalMode;
                plane = hit.transform.Find("Plane").gameObject;
                plane.SetActive(true);
                plane.GetComponent<ChangePlaneMaterial>().SetMaterial("gray");
                //renderer = hit.collider.gameObject.GetComponent<Renderer>();
                //changeRenderingMode.SetMaterialToTransparent(renderer.material);
                if (Input.GetMouseButtonDown(0))
                    Destroy(hit.collider.gameObject); // 건물 제거
            }
            else if (!hit.collider.CompareTag("Building") && isRemovalMode)
            {
                if (plane  != null)
                    plane.gameObject.SetActive(false);
                //material_ = hit.transform.gameObject.GetComponent<Renderer>().material;
                //changeRenderingMode.SetMaterialToOpaque(material_);
            }
        }
        dispositionScript.removeMode = isRemovalMode;
    }

    // 제거 버튼에 연결될 메소드
    public void EnableRemovalMode()
    {
        if (!dispositionScript.isPlacing)
        {
            isRemovalMode = !isRemovalMode; // 제거 모드 활성화 및 비활성화
        }
    }
    public void EnableRemovalMode_anotherButton()
    {
        isRemovalMode = false; // 다른 버튼을 클릭했을 시 remove mode 종료
    }
}