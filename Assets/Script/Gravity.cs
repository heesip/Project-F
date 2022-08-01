using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //�÷��̾ ������
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //�÷��̾� ������ �Ҵ��ϰ�
            player.rigid.gravityScale = 5.5f; //�÷��̾ �޴� �߷��� 5.5�� ����
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //�÷��̾ ����������
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //�÷��̾� ������ �Ҵ��ϰ�
            player.rigid.gravityScale = player.playerGravity; //�÷��̾ �޴� �߷��� �������� ����

        }
    }
}
