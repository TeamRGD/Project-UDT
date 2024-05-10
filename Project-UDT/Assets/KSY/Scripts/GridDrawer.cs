using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    public GameObject planeObject; // Plane 오브젝트
    public Material gridMaterial; // 그리드 라인의 머티리얼
    public float cellSize = 4f; // 셀 크기

    void Start()
    {
        if (planeObject == null)
        {
            Debug.LogError("Plane object is not assigned!");
            return;
        }

        Renderer planeRenderer = planeObject.GetComponent<Renderer>();
        if (planeRenderer == null)
        {
            Debug.LogError("Renderer component not found on the plane object!");
            return;
        }

        Vector3 planeSize = planeRenderer.bounds.size; // Plane의 크기 가져오기
        Vector3 planeCenter = planeRenderer.bounds.center; // Plane의 중심 가져오기
        Vector3 startPoint = planeCenter - planeSize * 0.5f; // 그리드 시작점 계산 (하단 왼쪽 모서리)

        int gridSizeX = Mathf.FloorToInt(planeSize.x / cellSize); // X축 그리드 수
        int gridSizeZ = Mathf.FloorToInt(planeSize.z / cellSize); // Z축 그리드 수

        DrawGrid(gridSizeX, gridSizeZ, startPoint);
    }

    void DrawGrid(int width, int height, Vector3 start)
    {
        for (int x = 0; x <= width; x++)
        {
            DrawLine(new Vector3(x * cellSize, 0, 0) + start, new Vector3(x * cellSize, 0, height * cellSize) + start);
        }
        for (int z = 0; z <= height; z++)
        {
            DrawLine(new Vector3(0, 0, z * cellSize) + start, new Vector3(width * cellSize, 0, z * cellSize) + start);
        }
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("GridLine");
        lineObj.transform.parent = this.transform;
        var lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.material = gridMaterial;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
