using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.2f); //���� ��(���� ��) 2.2�� �� �ڽ��� �ı�
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); //�ٸ� �ݶ��̴��� ������ �浹�� �Ͼ�� �ڽ��� �ı�
    }
}
