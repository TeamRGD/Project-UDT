using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPower : MonoBehaviour
{
    public float speed = 50.0f; // ȸ�� �ӵ�, �ʿ信 ���� ���� ����

    void Update()
    {
        // Z���� �߽����� ��ü�� ȸ����ŵ�ϴ�.
        // Time.deltaTime�� ����Ͽ� ������ �ӵ��� ������� �ϰ��� ȸ���� �����մϴ�.
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
