using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlaneMaterial : MonoBehaviour
{
    private Disposition dispositionScript;
    public Material redMaterial; // Ȱ�� ���¿��� ����� Material
    public Material greenMaterial; // ��Ȱ�� ���¿��� ����� Material
    public Material grayMaterial;
    new private Renderer renderer;


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
        if (!dispositionScript.CheckPlacing() && !dispositionScript.removeMode)
        {
            SetMaterial("red");
        }
        else if (dispositionScript.CheckPlacing() && !dispositionScript.removeMode)
        {
            SetMaterial("green");
        }

    }

    public void SetMaterial(string color_type)
    {
        if (color_type == "red")
        {
            renderer.material = redMaterial;
        }
        else if (color_type == "green")
        {
            renderer.material = greenMaterial;
        }
        else if (color_type == "gray")
        {
            renderer.material = grayMaterial;
        }
    }
}
