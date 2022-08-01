using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_jumpBox : MonoBehaviour
{
    public GameObject jumpBox; //�����ڽ� ������Ʈ
    public PlayerInfo player; //�÷��̾� ����
    AudioSource switchSound; //����ġ ����

    private void Awake()
    {
        switchSound = GetComponent<AudioSource>();
        jumpBox.SetActive(false); //�����ڽ� ��Ȱ��ȭ
    }
    private void Update()
    {
        if(player.rebon == true) //�÷��̾� ��Ȱ��
        {
            jumpBox.SetActive(false); //�����ڽ� ��Ȱ��ȭ
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switchSound.Play(); //���� ���
        jumpBox.SetActive(true); //���� �ڽ� Ȱ��ȭ
    }
}
