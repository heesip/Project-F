using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStone : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime); //Ư�� �ӵ��� �°� z������ ȸ��
    }
}
