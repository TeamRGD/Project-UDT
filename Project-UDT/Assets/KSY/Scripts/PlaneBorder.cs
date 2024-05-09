using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBorder : MonoBehaviour
{
    public Renderer targetRenderer; // 타겟 Plane의 Renderer 컴포넌트
    public float borderWidth = 0.1f; // 테두리의 두께

    private LineRenderer lineRenderer;

    void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Target renderer is not assigned!");
            return;
        }

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = Color.green; // 라인의 색상 설정
        lineRenderer.widthMultiplier = borderWidth;
        lineRenderer.positionCount = 5; // 폐쇄된 사각형이므로 5개의 점이 필요
    }

    void Update()
    {
        DrawBorder();
    }

    void DrawBorder()
    {
        Vector3 size = targetRenderer.bounds.size;
        Vector3 center = targetRenderer.bounds.center;

        // Plane 테두리의 꼭지점을 계산
        Vector3[] corners = new Vector3[5];
        corners[0] = new Vector3(center.x - size.x / 2, center.y, center.z - size.z / 2);
        corners[1] = new Vector3(center.x - size.x / 2, center.y, center.z + size.z / 2);
        corners[2] = new Vector3(center.x + size.x / 2, center.y, center.z + size.z / 2);
        corners[3] = new Vector3(center.x + size.x / 2, center.y, center.z - size.z / 2);
        corners[4] = corners[0]; // 시작점으로 돌아옴

        lineRenderer.SetPositions(corners); // 라인렌더러에 꼭지점 업데이트
    }
}