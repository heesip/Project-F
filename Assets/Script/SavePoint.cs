using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    AudioSource saveSound;//���̺� ���� 
     
    private void Awake()
    {
        saveSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //���̺�����Ʈ�� ���� �ݶ��̴��� �÷��̾��
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //�÷��̾� ������ ��������
            player.savePos = transform.position; //�÷��̾� ���̺� ������ �� ���̺� ����Ʈ �������� ����
            saveSound.Play(); //���� ���
        }
    }
}
