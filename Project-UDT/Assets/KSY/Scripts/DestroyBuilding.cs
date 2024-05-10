using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public bool isRemovalMode = false; // ���� ��� ���¸� �����ϴ� ����
    public Disposition dispositionScript;
    private GameObject plane;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // Ŭ���� ������Ʈ�� �ǹ����� Ȯ�� (���� ��� Tag�� ���)
            if (hit.collider.CompareTag("Building") && isRemovalMode)
            {
                Debug.Log("asdfasdf");
                plane = hit.transform.Find("Plane").gameObject;
                plane.SetActive(true);
                plane.GetComponent<ChangePlaneMaterial>().SetMaterial("gray");
                if (Input.GetMouseButtonDown(0))
                    Destroy(hit.collider.gameObject); // �ǹ� ����
            }
            else if (!hit.collider.CompareTag("Building") && isRemovalMode)
            {
                if (plane  != null)
                    plane.gameObject.SetActive(false);
            }
        }
        if (isRemovalMode)
        {
            Debug.Log("Remove mode");
        }
        dispositionScript.removeMode = isRemovalMode;
    }

    // ���� ��ư�� ����� �޼ҵ�
    public void EnableRemovalMode()
    {
        if (!dispositionScript.isPlacing)
        {
            isRemovalMode = !isRemovalMode; // ���� ��� Ȱ��ȭ �� ��Ȱ��ȭ
        }
    }
    public void EnableRemovalMode_anotherButton()
    {
        isRemovalMode = false; // �ٸ� ��ư�� Ŭ������ �� remove mode ����
    }
}