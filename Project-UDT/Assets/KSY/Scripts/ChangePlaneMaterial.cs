using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlaneMaterial : MonoBehaviour
{
    private Disposition dispositionScript;
    public Material redMaterial; // 활성 상태에서 사용할 Material
    public Material greenMaterial; // 비활성 상태에서 사용할 Material
    new private Renderer renderer;
    public bool isPlaced = false;


    void Start()
    {
        renderer = GetComponent<Renderer>(); // 객체의 Renderer 컴포넌트를 가져옵니다.
        // BuildingManager 오브젝트에서 Disposition 스크립트 찾기
        GameObject buildingManager = GameObject.Find("BuildingManager");
        if (buildingManager != null)
        {
            dispositionScript = buildingManager.GetComponent<Disposition>();
            if (dispositionScript == null)
            {
                Debug.LogError("Disposition script not found on BuildingManager!");
            }
        }
        else
        {
            Debug.LogError("BuildingManager object not found!");
        }
    }


    void Update()
    {
        if (!dispositionScript.CheckPlacing())
        {
            renderer.material = redMaterial; 
        }
        else 
        {
            renderer.material = greenMaterial;
        }

    }
}
