using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easter_egg : MonoBehaviour
{
    public GameManager manager;
    BoxCollider2D floorCol; //�̽��Ϳ��׷� ���� �������� ��(�ݶ��̴�)

    private void Awake()
    {
        floorCol = GetComponent<BoxCollider2D>(); 
        floorCol.enabled = false; //�̽��Ϳ��׷� ���� ���� ��Ȱ��ȭ
    }
    private void Update()
    {
        if(manager.secT > 10) //Ÿ�̸Ӱ� 10�ʰ� �Ѿ��
        {
            floorCol.enabled = true; //�̽��Ϳ��׷� ���ϴ� ���� Ȱ��ȭ
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //�÷��̾ ������
        {
            manager.stageLevel[0].SetActive(false); //���� ���������� ��Ȱ��ȭ
            manager.stageLevel[3].SetActive(true); //�̽��Ϳ��� ���������� Ȱ��ȭ

            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //���� �ݶ��̴��� playerInfo ��ũ��Ʈ�� ������
            player.transform.position = player.startPos; //�÷��̾� ��ġ ������ġ�� ����

            //Ÿ�̸� ��Ȱ��ȭ
            manager.TimeMinUI.enabled = false; 
            manager.TimeSecUI.enabled = false;
        }
    }
}
