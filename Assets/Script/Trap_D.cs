using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_D : Trap_Factory
{
    //플레이어가 부활해도 초기화 되지 않는 장애물
    private void Update()
    {
        Trap_ON(); //함정 활성화
        transform.Rotate(0, 0, -300 * Time.deltaTime); //회전하며 이동

        if (transform.position == target) //목표에 도착했을때 
            transform.position = ready; //함정 위치를 시작 위치로 이동
    }
}
