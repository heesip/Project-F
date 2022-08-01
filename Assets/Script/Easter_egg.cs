using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easter_egg : MonoBehaviour
{
    public GameManager manager;
    BoxCollider2D floorCol; //이스터에그로 가는 물리적인 길(콜라이더)

    private void Awake()
    {
        floorCol = GetComponent<BoxCollider2D>(); 
        floorCol.enabled = false; //이스터에그로 가는 길을 비활성화
    }
    private void Update()
    {
        if(manager.secT > 10) //타이머가 10초가 넘어가면
        {
            floorCol.enabled = true; //이스터에그로 향하는 길이 활성화
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //플레이어가 닿으면
        {
            manager.stageLevel[0].SetActive(false); //현재 스테이지를 비활성화
            manager.stageLevel[3].SetActive(true); //이스터에그 스테이지를 활성화

            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //닿은 콜라이더의 playerInfo 스크립트를 가져옴
            player.transform.position = player.startPos; //플레이어 위치 시작위치로 변경

            //타이머 비활성화
            manager.TimeMinUI.enabled = false; 
            manager.TimeSecUI.enabled = false;
        }
    }
}
