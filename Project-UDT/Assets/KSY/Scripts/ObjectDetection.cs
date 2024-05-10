using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    private Disposition dispositionScript;
    public Material buildingMaterial;
    private bool isTransparent = false;
    public float transparency = 0.5f;
    private Color originalColor;  // 원래의 색상을 저장할 변수
    public bool isPlaced = false;
    void Start()
    {
        originalColor = buildingMaterial.color;
        buildingMaterial = GetComponent<MeshRenderer>().material ;
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
        ToggleTransparency(isPlaced);
    }

    void ToggleTransparency(bool isPlaced)
    {
        if (!isPlaced && !isTransparent)
        {
            // 투명도를 높이기
            buildingMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, transparency);
            isTransparent = true;
        }
        else if (isPlaced)
        {
            // 투명도 복원
            buildingMaterial.color = originalColor;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            dispositionScript.SetPlacing(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            dispositionScript.SetPlacing(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            dispositionScript.SetPlacing(true);
        }
    }
}
