using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_A : Trap_Factory
{
    AudioSource operateSound; //함정 작동 사운드

    private void Awake()
    {
        operateSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //함정에 지정된 콜라이더에 플레이어가 들어오면
        {
            operate = true; //스위치 활성화
            operateSound.Play(); //사운드 실행
        }
    }

    private void Update()
    {
        if (player.rebon == true) //캐릭터가 부활시 
            Trap_OFF(); //함정 비활성화

        else if (operate == true) //함정 스위치 활성화시
            Trap_ON(); //함정 활성화
    }
}
