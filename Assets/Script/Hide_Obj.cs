using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Obj : MonoBehaviour
{
    SpriteRenderer objRen; // ������Ʈ �̹���
    PolygonCollider2D polygonCol; //�����浹 �ۿ��� �� �ݶ��̴�
    AudioSource  findSound; //������Ʈ �߰� ����
    CapsuleCollider2D capCol; //���� �ۿ��� �� �ݶ��̴�
    public PlayerInfo player; //�÷��̾� ����

    void Awake()
    {
        objRen = GetComponent<SpriteRenderer>();
        polygonCol = GetComponent<PolygonCollider2D>();
        capCol = GetComponent<CapsuleCollider2D>();
        findSound = GetComponent<AudioSource>();

        objRen.enabled = false; // �̹��� ��Ȱ��ȭ
        polygonCol.enabled = false; // ���� �浹 �ݶ��̴� ��Ȱ��ȭ
        capCol.enabled = true; //���� �ݶ��̴� Ȱ��ȭ

    }

    void Update()
    {
        if(player.rebon == true) //�÷��̾� ��Ȱ��
        {
            //���� ���۽� �ڽ� �ʱⰪ���� ����
            objRen.enabled = false; // �̹��� ��Ȱ��ȭ
            polygonCol.enabled = false; // ���� �浹 �ݶ��̴� ��Ȱ��ȭ
            capCol.enabled = true; //���� �ݶ��̴� Ȱ��ȭ

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Head") //�Ӹ��� ������
        {
            objRen.enabled = true; //�̹��� Ȱ��ȭ
            polygonCol.enabled = true; //���� �浹 �ݶ��̴� Ȱ��ȭ
            capCol.enabled = false; //���� �ݶ��̴� ��Ȱ��ȭ
            findSound.Play(); //���� ���
        }

    }

}
