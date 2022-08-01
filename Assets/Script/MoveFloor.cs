using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public Vector2 start; //���� ����
    public Vector2 end; //���� ����
    public Vector2 target; //��ǥ ����
    public bool moveSwitch; //�����̴� ���� �۵� ����ġ
    public float floorSpeed; //���ǿ����̴� �ӵ�
    public PlayerInfo player; //�÷��̾� ����

    void Awake()
    {
        moveSwitch = false; //�۵� OFF
        transform.position = start; //��ġ�� ������������ �̵�
        target = end; //��ǥ������ ������������ ����
    }

    void Update()
    {
        if (player.rebon == true) //�÷��̾ ��Ȱ��
        {
            moveSwitch = false; //����ġ ��Ȱ��ȭ
            transform.position = start; //��ġ�� ������������ �̵�
            target = end; //��ǥ������ ������������ ����
        }
    }
    private void FixedUpdate()
    {
        if (moveSwitch == true) //����ġ Ȱ��ȭ��
        {
            //��ǥ������ ���� �̵�
            transform.position = Vector2.MoveTowards(transform.position, target, floorSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target) <= 0.05f) //��ǥ������ �Ÿ��� 0.05���� ����� ����
        {
            if (target == end) //��ǥ������ ���������̸�
                target = start; // ��ǥ������ ����������� ����
            else // �ƴ� ���
                target = end; // ��ǥ������ ������������ ����
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") //������ �÷��̾�� ������
        {
            moveSwitch = true; //����ġ Ȱ��ȭ
        }
    }
}
