using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Obj : MonoBehaviour
{
    SpriteRenderer objRen; // 오브젝트 이미지
    PolygonCollider2D polygonCol; //물리충돌 작용을 할 콜라이더
    AudioSource  findSound; //오브젝트 발견 사운드
    CapsuleCollider2D capCol; //센서 작용을 할 콜라이더
    public PlayerInfo player; //플레이어 정보

    void Awake()
    {
        objRen = GetComponent<SpriteRenderer>();
        polygonCol = GetComponent<PolygonCollider2D>();
        capCol = GetComponent<CapsuleCollider2D>();
        findSound = GetComponent<AudioSource>();

        objRen.enabled = false; // 이미지 비활성화
        polygonCol.enabled = false; // 물리 충돌 콜라이더 비활성화
        capCol.enabled = true; //센서 콜라이더 활성화

    }

    void Update()
    {
        if(player.rebon == true) //플레이어 부활시
        {
            //게임 시작시 박스 초기값으로 변경
            objRen.enabled = false; // 이미지 비활성화
            polygonCol.enabled = false; // 물리 충돌 콜라이더 비활성화
            capCol.enabled = true; //센서 콜라이더 활성화

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Head") //머리가 닿으면
        {
            objRen.enabled = true; //이미지 활성화
            polygonCol.enabled = true; //물리 충돌 콜라이더 활성화
            capCol.enabled = false; //센서 콜라이더 비활성화
            findSound.Play(); //사운드 재생
        }

    }

}
