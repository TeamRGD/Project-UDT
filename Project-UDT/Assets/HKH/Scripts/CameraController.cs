using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float rotationSpeed = 0.1f; // ȸ�� �ӵ��� ���� ���߰ų� �� �����ϰ� ����

    public float Speed = 5.0f;
    private Transform target;
    private Color originalColor;
    private bool toggle = false; // ���� ���
    private MeshRenderer targetRenderer;


    private void Update()
    {
        HandleRotation();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (target == null) // ���� Ÿ���� �������� �ʾҴٸ� Ÿ���� ã���ϴ�.
            {
                GameObject followCam = GameObject.FindGameObjectWithTag("FollowCam");
                if (followCam != null)
                {
                    target = followCam.transform;
                    targetRenderer = followCam.GetComponent<MeshRenderer>();
                    originalColor = targetRenderer.material.color;
                }
            }

            if (target != null)
            {
                if (toggle) // �̹� Ȱ��ȭ�� ���¶�� ���� ������� ������ �ڷ�ƾ�� ����ϴ�.
                {
                    StopCoroutine("MoveToTarget");
                    targetRenderer.material.color = originalColor;
                }
                else // ��Ȱ��ȭ ���¶�� ���� �����ϰ� �ڷ�ƾ�� �����մϴ�.
                {
                    targetRenderer.material.color = Color.red;
                    StartCoroutine("MoveToTarget");
                }
                toggle = !toggle;
            }
        }
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1)) // ��Ŭ���� �����ϴ� ����
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime * 10; // �ӵ� ���Ҹ� ���� ������ ����
            float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * 10; // �ӵ� ���Ҹ� ���� ������ ����

            transform.eulerAngles += new Vector3(mouseY, mouseX, 0);
        }
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButton(1)) // ��Ŭ���� �����ϴ� ����
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.E))
                transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.Q))
                transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        }
    }
    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, target.position - target.forward * 5 + target.up * 1) > 0.1f)
        {
            Vector3 targetPosition = target.position - target.forward * 5 + target.up * 1; // Ÿ�� �� 5 ����, ���� 1 ����
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
            transform.LookAt(target);
            yield return null;
        }
    }
}