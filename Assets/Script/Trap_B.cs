using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_B : Trap_Factory
{
    private void Update()
    {
        if (player.rebon == true || transform.position == target) //ĳ���Ͱ� ��Ȱ�� Ȥ�� Ÿ�ٿ� ��ġ������ 
            transform.position = ready; //���� ��ġ�� ���� ��ġ�� �̵�
        else //���Ͱ��� ��Ȳ�� �ƴ϶�� 
        {
            Trap_ON(); //���� Ȱ��ȭ
        }

    }

}
