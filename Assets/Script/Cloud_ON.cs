using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_ON : Cloud
{
    AudioSource switchSound; //스위치 사운드

    void Awake()
    {
        switchSound = GetComponent<AudioSource>();
        cloudSwitch = true; //스위치 활성화
        Operate(); //눈 생성 작동
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime; //생성 타이머에 실제 시간을 계속 더해줌
        if (spawnTimer > spawnRate && cloudSwitch == true) //생성타이머가 생성주기보다 커지고 스위치가 켜져있으면 
        {
            Snow_Spawn1();   //1번 소환
            Invoke("Snow_Spawn3", 0.1f); //3번을 0.1초 뒤에 소환
            Invoke("Snow_Spawn2", 0.2f); //2번을 0.2초 뒤에 소환
            Operate(); //눈 생성 작동을 다시 불러와서 생성타이머 초기화 및 생성주기 재설정
        }
        else if(player.rebon == true) //플레이어 부활시 
        {
            cloudSwitch = true; //스위치 활성화
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //지정위치에 닿으면
        {
            cloudSwitch = false; //스위치 비활성화
            switchSound.Play(); //사운드 재생
        }
    }
}
