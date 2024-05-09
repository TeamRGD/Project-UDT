using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBorder : MonoBehaviour
{
    public Renderer targetRenderer; // Ÿ�� Plane�� Renderer ������Ʈ
    public float borderWidth = 0.1f; // �׵θ��� �β�

    private LineRenderer lineRenderer;
    private Disposition dispositionScript;
    public bool isPlaced = false;

    void Start()
    {
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

        if (targetRenderer == null)
        {
            Debug.LogError("Target renderer is not assigned!");
            return;
        }

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = Color.green; // ������ ���� ����
        lineRenderer.widthMultiplier = borderWidth;
        lineRenderer.positionCount = 5; // ���� �簢���̹Ƿ� 5���� ���� �ʿ�
    }

    void Update()
    {
        DrawBorder();
    }

    void DrawBorder()
    {
        Vector3 size = targetRenderer.bounds.size;
        Vector3 center = targetRenderer.bounds.center;

        // Plane �׵θ��� �������� ���
        Vector3[] corners = new Vector3[5];
        corners[0] = new Vector3(center.x - size.x / 2, center.y, center.z - size.z / 2);
        corners[1] = new Vector3(center.x - size.x / 2, center.y, center.z + size.z / 2);
        corners[2] = new Vector3(center.x + size.x / 2, center.y, center.z + size.z / 2);
        corners[3] = new Vector3(center.x + size.x / 2, center.y, center.z - size.z / 2);
        corners[4] = corners[0]; // ���������� ���ƿ�

        lineRenderer.SetPositions(corners); // ���η������� ������ ������Ʈ

        if (!dispositionScript.CheckPlacing())  
        {
            lineRenderer.material.color = Color.red;
        }
        else
        {
            lineRenderer.material.color = Color.green;
        }
    }
}