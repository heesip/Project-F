using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float spawnRateMin = 0.3f; //���� �ֱ� �ּҰ�
    public float spawnRateMax = 0.7f; //���� �ֱ� �ִ밪
    public float spawnRate; //���� �ֱ� 
    public float spawnTimer; //����Ÿ�̸�

    public GameObject snowPrefab; //�� ������
    public Transform [] pos; //���� �������� ��ġ �迭�� ����� 
    public bool cloudSwitch; //�۵� ����ġ
    public PlayerInfo player; //�÷��̾� ����


   
    public void Snow_Spawn1() //�� 1�� ��ȯ
    {
        GameObject snow1 = Instantiate(snowPrefab, pos[0]); //pos 0���� ����
    }
    public void Snow_Spawn2() //�� 2�� ��ȯ
    {
        GameObject snow2 = Instantiate(snowPrefab, pos[1]); //pos 1���� ����
    }
    public void Snow_Spawn3() //�� 3�� ��ȯ
    {        
        GameObject snow3 = Instantiate(snowPrefab, pos[2]); //pos 2���� ����       
    }

    public void Operate() //�� ���� �۵� �Լ�
    {
        spawnTimer = 0f; //���� Ÿ�̸� 0���� �ʱ�ȭ

        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //�����ֱ⸦ �ּҰ��� �ִ밪���� �������� ����

    }


}
