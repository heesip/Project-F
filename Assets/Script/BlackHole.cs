using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    SpriteRenderer blackHole_Ren; //��Ȧ �̹���
    public PlayerInfo player;
    private void Awake()
    {
        blackHole_Ren = GetComponent<SpriteRenderer>();
        blackHole_Ren.enabled = false; //�̹����� ��Ȱ��ȭ

    }
    private void Update()
    {
        if (player.rebon == true) //�÷��̾� ��Ȱ�� 
        {
            blackHole_Ren.enabled = false;  //�̹����� ��Ȱ��ȭ
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //��Ȧ ���������� �÷��̾ ������
        {
            blackHole_Ren.enabled = true; //�̹����� Ȱ��ȭ
        }
    }

   
}
