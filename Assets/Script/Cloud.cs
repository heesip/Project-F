using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float spawnRateMin = 0.3f; //생성 주기 최소값
    public float spawnRateMax = 0.7f; //생성 주기 최대값
    public float spawnRate; //생성 주기 
    public float spawnTimer; //생성타이머

    public GameObject snowPrefab; //눈 프리팹
    public Transform[] pos; //눈을 내리게할 위치 배열로 잡아줌 
    public bool cloudSwitch; //작동 스위치
    public PlayerInfo player; //플레이어 정보



    public void Snow_Spawn1() //눈 1번 소환
    {
        GameObject snow1 = Instantiate(snowPrefab, pos[0]); //pos 0번에 생성
    }
    public void Snow_Spawn2() //눈 2번 소환
    {
        GameObject snow2 = Instantiate(snowPrefab, pos[1]); //pos 1번에 생성
    }
    public void Snow_Spawn3() //눈 3번 소환
    {
        GameObject snow3 = Instantiate(snowPrefab, pos[2]); //pos 2번에 생성       
    }

    public void Operate() //눈 생성 작동 함수
    {
        spawnTimer = 0f; //생성 타이머 0으로 초기화

        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //생성주기를 최소값과 최대값사이 랜덤으로 설정

    }


}
