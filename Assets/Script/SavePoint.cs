using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    AudioSource saveSound;//세이브 사운드 
     
    private void Awake()
    {
        saveSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //세이브포인트에 닿은 콜라이더가 플레이어면
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //플레이어 정보를 가져오고
            player.savePos = transform.position; //플레이어 세이브 지점을 현 세이브 포인트 지점으로 변경
            saveSound.Play(); //사운드 재생
        }
    }
}
