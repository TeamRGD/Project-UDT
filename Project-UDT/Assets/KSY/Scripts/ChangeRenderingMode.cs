using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRenderingMode : MonoBehaviour
{
    private Material material_;
    private ObjectDetection objectDetection;
    public bool isRemoveMode = false;

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
        else if (!isRemoveMode && !objectDetection.isPlaced)
        {
            Debug.Log("asdfasdfsGWGWEFEW");
            SetMaterialToTransparent(material_);
        }
    }

    public void SetMaterialToOpaque(Material mat)
    {
        if (mat != null)
        {
            // ������ ��带 Opaque�� ����
            mat.SetFloat("_Mode", 0);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1); // Z-buffer�� ���� Ȱ��ȭ
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.SetOverrideTag("RenderType", "");
            mat.renderQueue = -1; // �⺻ ���� ť�� ����

            // Standard ���̴��� ����ŧ�� ���̶���Ʈ�� �۷ν� �ݻ縦 ��Ȱ��ȭ
            mat.SetFloat("_Glossiness", 0.5f); // �� ���� �����Ϳ��� ������ �۷νôϽ� ���� ����ؾ� �մϴ�.
            mat.SetFloat("_Metallic", 0.5f); // �� ���� �����Ϳ��� ������ ��Ż�� ���� ����ؾ� �մϴ�.
        }
        else
        {
            Debug.LogError("Material is not assigned or is null.");
        }
    }

    public void SetMaterialToTransparent(Material mat)
    {
        if (mat != null)
        {
            // ������ ��带 Transparent�� ����
            mat.SetFloat("_Mode", 3);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0); // Z-buffer�� ���� ��Ȱ��ȭ
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000; // Transparent ���� ť

            // 'Standard' ���̴��� ���, �̷��� ���־�� �մϴ�.
            mat.SetOverrideTag("RenderType", "Transparent");
            mat.SetFloat("_Glossiness", 0f);
            mat.SetFloat("_Metallic", 0f);

            // Shader�� ������ ������Ʈ�մϴ�.
            mat.EnableKeyword("TRANSPARENT");
            mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
        }
        else
        {
            Debug.LogError("Material is not assigned or is null.");
        }
    }
}
