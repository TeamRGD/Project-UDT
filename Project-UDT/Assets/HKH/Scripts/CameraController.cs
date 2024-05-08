using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float rotationSpeed = 0.1f; // ȸ�� �ӵ��� ���� ���߰ų� �� �����ϰ� ����

    private void Update()
    {
        HandleRotation();
        HandleMovement();
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
}