using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private Material buildingMaterial;
    public float transparency = 0.5f;  // 원하는 투명도 수준
    private bool isTransparent = false;  // 투명도가 변경되었는지 여부
    private Color originalColor;  // 원래의 색상을 저장할 변수

    void Start()
    {
        // MeshRenderer에서 Material을 가져옵니다.
        buildingMaterial = GetComponent<MeshRenderer>().material;
        // 초기 색상 저장
        originalColor = buildingMaterial.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleTransparency();
        }
    }

    void ToggleTransparency()
    {
        if (!isTransparent)
        {
            // 투명도를 높이기
            buildingMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, transparency);
            isTransparent = true;
        }
        else
        {
            // 투명도 복원
            buildingMaterial.color = originalColor;
            isTransparent = false;
        }
    }
}