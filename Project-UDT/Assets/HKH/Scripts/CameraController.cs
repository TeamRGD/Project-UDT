using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float rotationSpeed = 0.1f; // 회전 속도를 대폭 낮추거나 더 세밀하게 조정

    private void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1)) // 우클릭을 유지하는 동안
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime * 10; // 속도 감소를 위해 스케일 조정
            float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * 10; // 속도 감소를 위해 스케일 조정

            transform.eulerAngles += new Vector3(mouseY, mouseX, 0);
        }
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButton(1)) // 우클릭을 유지하는 동안
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