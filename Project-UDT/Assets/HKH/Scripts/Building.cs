using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private Material buildingMaterial;
    public float transparency = 0.5f;  // ���ϴ� ���� ����
    private bool isTransparent = false;  // ������ ����Ǿ����� ����
    private Color originalColor;  // ������ ������ ������ ����

    void Start()
    {
        // MeshRenderer���� Material�� �����ɴϴ�.
        buildingMaterial = GetComponent<MeshRenderer>().material;
        // �ʱ� ���� ����
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
            // ������ ���̱�
            buildingMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, transparency);
            isTransparent = true;
        }
        else
        {
            // ���� ����
            buildingMaterial.color = originalColor;
            isTransparent = false;
        }
    }
}