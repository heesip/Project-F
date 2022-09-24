using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public Vector2 start; //시작 지점
    public Vector2 end; //도착 지점
    public Vector2 target; //목표 지점
    public bool moveSwitch; //움직이는 발판 작동 스위치
    public float floorSpeed; //발판움직이는 속도
    public PlayerInfo player; //플레이어 정보

    void Awake()
    {
        moveSwitch = false; //작동 OFF
        transform.position = start; //위치를 시작지점으로 이동
        target = end; //목표지점을 도착지점으로 지정
    }

    void Update() //(이벤트로 변경할필요있으..)
    {
        if (player.rebon == true) //플레이어가 부활시
        {
            moveSwitch = false; //스위치 비활성화
            transform.position = start; //위치를 시작지점으로 이동
            target = end; //목표지점을 도착지점으로 지정
        }
    }
    private void FixedUpdate()
    {
        if (moveSwitch == true) //스위치 활성화시
        {
            //목표지점을 향해 이동
            transform.position = Vector2.MoveTowards(transform.position, target, floorSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target) <= 0.05f) //목표지점에 거리가 0.05보다 가까워 지면
        {
            if (target == end) //목표지점이 도착지점이면
                target = start; // 목표지점을 출발지점으로 설정
            else // 아닌 경우
                target = end; // 목표지점을 도착지점으로 설정
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //발판이 플레이어와 닿으면
        {
            moveSwitch = true; //스위치 활성화
        }
    }
}
