using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFlag : MonoBehaviour
{
    AudioSource fakeFlagSound; //페이크 깃발 사운드
    SpriteRenderer ren; //깃발 이미지
    public PlayerInfo player; //플레이어 정보

    private void Awake()
    {
        fakeFlagSound = GetComponent<AudioSource>();
        ren = GetComponent<SpriteRenderer>();
        ren.enabled = true; //이미지 활성화

    }
    private void Update()
    {
        if (player.rebon == true) //플레이어 부활시
        {
            ren.enabled = true; //이미지 활성화
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //플레이어가 닿으면
        {
            ren.enabled = false; //이미지 비활성화
            fakeFlagSound.Play(); //사운드 재생
        }


    }
}
