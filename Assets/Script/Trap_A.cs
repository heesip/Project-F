using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_A : Trap_Factory
{
    AudioSource operateSound; //���� �۵� ����

    private void Awake()
    {
        operateSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //������ ������ �ݶ��̴��� �÷��̾ ������
        {
            operate = true; //����ġ Ȱ��ȭ
            operateSound.Play(); //���� ����
        }
    }

    private void Update()
    {
        if (player.rebon == true) //ĳ���Ͱ� ��Ȱ�� 
            Trap_OFF(); //���� ��Ȱ��ȭ

        else if (operate == true) //���� ����ġ Ȱ��ȭ��
            Trap_ON(); //���� Ȱ��ȭ
    }
}
