using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_D : Trap_Factory
{
    //�÷��̾ ��Ȱ�ص� �ʱ�ȭ ���� �ʴ� ��ֹ�
    private void Update()
    {
        Trap_ON(); //���� Ȱ��ȭ
        transform.Rotate(0, 0, -300 * Time.deltaTime); //ȸ���ϸ� �̵�

        if (transform.position == target) //��ǥ�� ���������� 
            transform.position = ready; //���� ��ġ�� ���� ��ġ�� �̵�
    }

}
