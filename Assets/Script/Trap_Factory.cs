using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Factory : MonoBehaviour
{
    public PlayerInfo player => PlayerInfo.Instance; //플레이어 정보
    public Vector3 ready; //함정 시작 위치
    public Vector3 target; //함정 타겟 위치
    public bool operate; //함정 작동 활성화 여부
    public float operateSpeed; //함정 작동 속도


    public void Trap_ON() //함정 활성화 함수
    {
        //함정 위치를 지정 위치로 지정 속도로 이동
        transform.position = Vector3.MoveTowards(transform.position, target, operateSpeed * Time.deltaTime);
    }

    public void Trap_OFF() //함정 비활성화 함수
    {
        operate = false; //함정 스위치 비활성화
        transform.position = ready; //함정 위치를 시작 위치로 이동
    }
}
