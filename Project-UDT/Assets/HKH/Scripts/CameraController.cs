using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float rotationSpeed = 0.1f; // 회전 속도를 대폭 낮추거나 더 세밀하게 조정

    public float Speed = 5.0f;
    private Transform target;
    private Color originalColor;
    private bool toggle = false; // 상태 토글
    private MeshRenderer targetRenderer;


    private void Update()
    {
        HandleRotation();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (target == null) // 아직 타겟이 설정되지 않았다면 타겟을 찾습니다.
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
                if (toggle) // 이미 활성화된 상태라면 색을 원래대로 돌리고 코루틴을 멈춥니다.
                {
                    StopCoroutine("MoveToTarget");
                    targetRenderer.material.color = originalColor;
                }
                else // 비활성화 상태라면 색을 변경하고 코루틴을 시작합니다.
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
    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, target.position - target.forward * 5 + target.up * 1) > 0.1f)
        {
            Vector3 targetPosition = target.position - target.forward * 5 + target.up * 1; // 타겟 앞 5 유닛, 위로 1 유닛
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
            transform.LookAt(target);
            yield return null;
        }
    }
}