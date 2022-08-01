using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerInfo player; //�÷��̾� ����
    public GameObject[] stageLevel; //�������� �迭
    public int stage; //�������� ��ȣ
    public GameObject ClearUI; //Ŭ���� UI
    public GameObject RetryUI; //��Ʈ���� UI
    public Text TimeSecUI; //Ÿ�̸� �� UI
    public Text TimeMinUI; //Ÿ�̸� �� UI
    public float secT; // Ÿ�̸� ��
    float minT; //Ÿ�̸� ��
    public bool timerStart; //Ÿ�̸� ���� ����
    public GameObject playerC; //�÷��̾� ĳ����
    public FollowCam cam; //ī�޶�

    private void Awake()
    {
        ClearUI.SetActive(false); //Ŭ���� UI ��Ȱ��ȭ
        RetryUI.SetActive(false); //��Ʈ���� UI ��Ȱ��ȭ
        timerStart = true; // Ÿ�̸� Ȱ��ȭ
    }
    void Update()
    {
        if(timerStart == true) //Ÿ�̸Ӱ� �۵����̸�
        {
            secT += UnityEngine.Time.deltaTime; //�����ð��� �����ͼ� ������
            TimeSecUI.text = secT.ToString("00.00");  //�ʿ� 00.00�� ���� ������ �ð�ó�� ������
            TimeMinUI.text = minT.ToString() + ":";  //�п� : �� �߰��� �ʿ� ����
            if(secT >= 60) // 60�ʰ� ������
            {
                secT = 0.00f; //�ʸ� 0�ʷ� ������
                minT++; //1���� ����
            }
        }

        if (Input.GetButtonDown("Reset")) //���¹�ưP�� ������
        {
            SceneManager.LoadScene(0); //�� 0�� �ҷ��� �� �ʱ�ȭ
        }
    }
    public void NextLevel() //���� ���� �Լ�
    {
        ClearUI.SetActive(false); //Ŭ���� UI ��Ȱ��ȭ
        if(stage < 2) //�������� ��ȣ�� 2 �̸��̸�
        {
            stageLevel[stage].SetActive(false); //���� ���������� ��Ȱ��ȭ
            stage++; //�������� ��ȣ 1������
            stageLevel[stage].SetActive(true); //�ش� ���������� Ȱ��ȭ
            player.transform.position = player.startPos; //�÷��̾� ��ġ ��ŸƮ ��ġ�� ����
            player.rigid.velocity = Vector2.zero; //�÷��̾�� ���� ���ӵ� �ʱ�ȭ
            cam.StopCoroutine("NextCam");
            cam.StartCoroutine("NextCam");
            player.savePos = player.startPos; //�÷��̾� ���̺� ����Ʈ ��ŸƮ ��ġ�� ����
            timerStart = true; //Ÿ�̸� Ȱ��ȭ

            if (stage == 2) //�������� ��ȣ�� 2���̸� (3��������)
            {
                //�ش� ���������� ������ �߷°� ���� ���� ���� ���� 
                player.playerGravity = player.spaceGravity; 
                player.rigid.gravityScale = player.playerGravity;
                player.jumpLimit = 1;
            }
            else
                return; 

        }

        else
        {
            stageLevel[stage].SetActive(false); //���� ���������� ��Ȱ��ȭ
            stageLevel[4].SetActive(true); //Ŭ���� ȭ�� �ҷ���
            playerC.SetActive(false); //ĳ���� ��Ȱ��ȭ
        }

    }
    public void Retry() //UI�� ���� ����� Retry �÷��̾�� �ִ� ��Ȱ �ڷ�ƾ �ҷ���
    {
        //��Ȱ �ڷ�ƾ
        player.StopCoroutine("Rebon"); 
        player.StartCoroutine("Rebon");
    }
   
}
