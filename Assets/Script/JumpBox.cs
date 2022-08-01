using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    AudioSource boxSound; //���� �ڽ� ����
    public float boxPower; //�ڽ� �Ŀ�

    private void Awake()
    {
        boxSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //�ݶ��̴��� �÷��̾ ������
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //�÷��̾� ������ �Ҵ��ϰ�
            player.rigid.AddForce(Vector2.up * boxPower, ForceMode2D.Impulse); //�÷��̾ �Ŀ� �� ��ŭ ������ ������Ŵ
            boxSound.Play(); //���� ���
        }
    }
    
}
