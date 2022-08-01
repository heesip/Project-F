using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStone : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime); //특정 속도에 맞게 z축으로 회전
    }
}
