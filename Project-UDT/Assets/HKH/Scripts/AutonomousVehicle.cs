using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousVehicle : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5.0f;
    private float rotationSpeed = 100.0f;  // 회전 속도
    private int waypointIndex = 0;

    private void Update()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        Transform targetWaypoint = waypoints[waypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // 오브젝트가 이동 방향을 바라보도록 회전
        Vector3 direction = targetWaypoint.position - transform.position;
        if (direction != Vector3.zero)  // 방향 벡터가 0이 아닐 때만 회전 처리
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f) // 거의 도착했을 때
        {
            waypointIndex++; // 다음 waypoint로 인덱스 증가
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0; // 마지막 waypoint에 도달했다면 인덱스를 0으로 리셋
            }
        }
    }
}