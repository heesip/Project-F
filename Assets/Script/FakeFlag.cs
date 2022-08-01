using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFlag : MonoBehaviour
{
    AudioSource fakeFlagSound; //����ũ ��� ����
    SpriteRenderer ren; //��� �̹���
    public PlayerInfo player; //�÷��̾� ����

    private void Awake()
    {
        fakeFlagSound = GetComponent<AudioSource>();
        ren = GetComponent<SpriteRenderer>();
        ren.enabled = true; //�̹��� Ȱ��ȭ

    }
    private void Update()
    {
        if (player.rebon == true) //�÷��̾� ��Ȱ��
        {
            ren.enabled = true; //�̹��� Ȱ��ȭ
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //�÷��̾ ������
        {
            ren.enabled = false; //�̹��� ��Ȱ��ȭ
            fakeFlagSound.Play(); //���� ���
        }


    }
}
