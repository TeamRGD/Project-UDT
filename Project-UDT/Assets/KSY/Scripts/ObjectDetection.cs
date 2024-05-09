using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    private Disposition dispositionScript;

    void Start()
    {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            dispositionScript.CantPlacing();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            dispositionScript.CanPlacing();
        }
    }
}
