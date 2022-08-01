using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_OFF : Cloud
{
    AudioSource switchSound; //����ġ ����

    void Awake() 
    {
        switchSound = GetComponent<AudioSource>();
        cloudSwitch = false; //����ġ ��Ȱ��ȭ
        Operate(); //�� ���� �۵�
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime; //���� Ÿ�̸ӿ� ���� �ð��� ��� ������
        if (spawnTimer > spawnRate && cloudSwitch == true) //���� Ÿ�̸Ӱ� ���� �ֱ⺸�� Ŀ���� ����ġ�� Ȱ��ȭ ���¸�
        {
            Snow_Spawn1();   //1�� ��ȯ
            Invoke("Snow_Spawn3", 0.1f); //3���� 0.1�� �ڿ� ��ȯ
            Invoke("Snow_Spawn2", 0.2f); //2���� 0.2�� �ڿ� ��ȯ
            Operate(); //�� ���� �۵��� �ٽ� �ҷ��ͼ� ����Ÿ�̸� �ʱ�ȭ �� �����ֱ� �缳��
        }
        else if (player.rebon == true) //�÷��̾� ��Ȱ�� 
        {
            cloudSwitch = false; //����ġ ��Ȱ��ȭ
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //���� ��ġ�� ������
        {
            cloudSwitch = true; //����ġ Ȱ��ȭ
            switchSound.Play(); //���� ���
        }        
    }
}
