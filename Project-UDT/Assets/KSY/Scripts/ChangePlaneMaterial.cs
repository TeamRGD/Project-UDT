using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlaneMaterial : MonoBehaviour
{
    private Disposition dispositionScript;
    public Material redMaterial; // Ȱ�� ���¿��� ����� Material
    public Material greenMaterial; // ��Ȱ�� ���¿��� ����� Material
    new private Renderer renderer;
    public bool isPlaced = false;


    void Start()
    {
        renderer = GetComponent<Renderer>(); // ��ü�� Renderer ������Ʈ�� �����ɴϴ�.
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
