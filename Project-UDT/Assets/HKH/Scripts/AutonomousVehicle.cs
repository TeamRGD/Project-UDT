using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousVehicle : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5.0f;
    private float rotationSpeed = 100.0f;  // ȸ�� �ӵ�
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

        // ������Ʈ�� �̵� ������ �ٶ󺸵��� ȸ��
        Vector3 direction = targetWaypoint.position - transform.position;
        if (direction != Vector3.zero)  // ���� ���Ͱ� 0�� �ƴ� ���� ȸ�� ó��
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f) // ���� �������� ��
        {
            waypointIndex++; // ���� waypoint�� �ε��� ����
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0; // ������ waypoint�� �����ߴٸ� �ε����� 0���� ����
            }
        }
    }
}