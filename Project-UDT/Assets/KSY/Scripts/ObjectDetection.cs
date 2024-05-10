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
    private Color originalColor;  // ������ ������ ������ ����
    public bool isPlaced = false;
    void Start()
    {
        originalColor = buildingMaterial.color;
        buildingMaterial = GetComponent<MeshRenderer>().material;
        // BuildingManager ������Ʈ���� Disposition ��ũ��Ʈ ã��
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
            // ������ ���̱�
            buildingMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, transparency);
            isTransparent = true;
        }
        else if (isPlaced)
        {
            // ���� ����
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
