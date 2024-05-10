using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPower : MonoBehaviour
{
    public float speed = 50.0f; // 회전 속도, 필요에 따라 조정 가능

    void Update()
    {
        // Z축을 중심으로 객체를 회전시킵니다.
        // Time.deltaTime을 사용하여 프레임 속도에 관계없이 일관된 회전을 보장합니다.
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
