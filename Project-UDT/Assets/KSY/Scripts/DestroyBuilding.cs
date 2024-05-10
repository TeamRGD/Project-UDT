using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public bool isRemovalMode = false; // ���� ��� ���¸� �����ϴ� ����
    public Disposition dispositionScript;
    private GameObject plane;
    private Material material_;
    new private Renderer renderer;
    public int id_;
    public bool isRemoved = false;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // Ŭ���� ������Ʈ�� �ǹ����� Ȯ�� (���� ��� Tag�� ���)
            if (hit.collider.CompareTag("Building") && isRemovalMode)
            {
                //changeRenderingMode = hit.collider.gameObject.GetComponent<ChangeRenderingMode>();
                //changeRenderingMode.isRemoveMode = isRemovalMode;
                plane = hit.transform.Find("Plane").gameObject;
                plane.SetActive(true);
                plane.GetComponent<ChangePlaneMaterial>().SetMaterial("gray");
                id_ = hit.transform.GetComponent<ObjectDetection>().id;

                //renderer = hit.collider.gameObject.GetComponent<Renderer>();
                //changeRenderingMode.SetMaterialToTransparent(renderer.material);
                if (Input.GetMouseButtonDown(0))
                {
                    isRemoved = true;
                    Destroy(hit.collider.gameObject); // �ǹ� ����
                }
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