using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRenderingMode : MonoBehaviour
{
    private Material material_;
    private ObjectDetection objectDetection;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        material_ = renderer.material;
        objectDetection = GetComponent<ObjectDetection>();
    }

    void Update()
    {
        if (objectDetection.isPlaced)
        {
            SetMaterialToOpaque(material_);
        }
        else
        {
            SetMaterialToTransparent(material_);
        }
    }

    void SetMaterialToOpaque(Material mat)
    {
        if (mat != null)
        {
            // 렌더링 모드를 Opaque로 변경
            mat.SetFloat("_Mode", 0);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1); // Z-buffer에 쓰기 활성화
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.SetOverrideTag("RenderType", "");
            mat.renderQueue = -1; // 기본 렌더 큐로 설정

            // Standard 쉐이더의 스펙큘러 하이라이트와 글로시 반사를 재활성화
            mat.SetFloat("_Glossiness", 0.5f); // 이 값은 에디터에서 조정된 글로시니스 값을 사용해야 합니다.
            mat.SetFloat("_Metallic", 0.5f); // 이 값도 에디터에서 조정된 메탈릭 값을 사용해야 합니다.
        }
        else
        {
            Debug.LogError("Material is not assigned or is null.");
        }
    }

    void SetMaterialToTransparent(Material mat)
    {
        if (mat != null)
        {
            // 렌더링 모드를 Transparent로 변경
            mat.SetFloat("_Mode", 3);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0); // Z-buffer에 쓰기 비활성화
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000; // Transparent 렌더 큐

            // 'Standard' 쉐이더의 경우, 이렇게 해주어야 합니다.
            mat.SetOverrideTag("RenderType", "Transparent");
            mat.SetFloat("_Glossiness", 0f);
            mat.SetFloat("_Metallic", 0f);

            // Shader를 강제로 업데이트합니다.
            mat.EnableKeyword("TRANSPARENT");
            mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
        }
        else
        {
            Debug.LogError("Material is not assigned or is null.");
        }
    }
}
