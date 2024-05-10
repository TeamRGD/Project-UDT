using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousVehicle : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5.0f;
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