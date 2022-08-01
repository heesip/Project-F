using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_B : Trap_Factory
{
    private void Update()
    {
        if (player.rebon == true || transform.position == target) //캐릭터가 부활시 혹은 타겟에 위치했을때 
            transform.position = ready; //함정 위치를 시작 위치로 이동
        else //위와같은 상황이 아니라면 
        {
            Trap_ON(); //함정 활성화
        }

    }

}
