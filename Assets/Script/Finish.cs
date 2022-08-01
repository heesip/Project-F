using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager manager; //���� �Ŵ���
    AudioSource finsihSound; //���� ����
    private void Awake()
    {
        finsihSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Player") //�÷��̾ ������
        {
            manager.ClearUI.SetActive(true); //Ŭ���� UI�� Ȱ��ȭ
            manager.timerStart = false; //Ÿ�̸� �Ͻ�����
            finsihSound.Play(); //���� ���
        }
    }

}
