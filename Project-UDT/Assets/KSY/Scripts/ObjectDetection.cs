using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    private Disposition dispositionScript;
    public Material buildingMaterial;
    private bool flag = false;
    void Start()
    {
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
        if (!dispositionScript.isPlacing && !flag)
        {
            Color color = buildingMaterial.color; // ���� ������ ������
            color.a = 255; // ���� ��(������) ����
            flag = true;
            buildingMaterial.color = new Color(color.r, color.g, color.b, 100); // ����� ������ ���׸��� ����
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
