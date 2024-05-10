using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float rotationSpeed = 0.1f;
    public float speed = 5.0f;
    private Transform target;
    private bool toggle = false;
    private List<MeshRenderer> targetRenderers = new List<MeshRenderer>();
    private List<Color> originalColors = new List<Color>();

    private void Update()
    {
        HandleRotation();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!toggle) // 타겟이 처음 설정될 때
            {
                GameObject[] followCams = GameObject.FindGameObjectsWithTag("FollowCam");
                foreach (GameObject cam in followCams)
                {
                    MeshRenderer renderer = cam.GetComponent<MeshRenderer>();
                    if (renderer != null)
                    {
                        targetRenderers.Add(renderer);
                        originalColors.Add(renderer.material.color);
                        renderer.material.color = Color.red;
                    }
                }

                // 랜덤 타겟 선택
                int randomIndex = Random.Range(0, followCams.Length);
                target = followCams[randomIndex].transform;
                StartCoroutine("MoveToTarget");
            }
            else // 토글이 다시 활성화된 경우
            {
                StopCoroutine("MoveToTarget");
                for (int i = 0; i < targetRenderers.Count; i++)
                {
                    targetRenderers[i].material.color = originalColors[i];
                }
                targetRenderers.Clear();
                originalColors.Clear();
            }
            toggle = !toggle;
        }
    }

    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, target.position - target.forward * 5 + target.up * 1) > 0.1f)
        {
            Vector3 targetPosition = target.position - target.forward * -50 + target.up * 10;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.LookAt(target);
            yield return null;
        }
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime * 10;
            float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * 10;
            transform.eulerAngles += new Vector3(mouseY, mouseX, 0);
        }
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButton(1))
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
