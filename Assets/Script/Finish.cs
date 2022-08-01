using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager manager; //게임 매니저
    AudioSource finsihSound; //도착 사운드
    private void Awake()
    {
        finsihSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Player") //플레이어가 닿으면
        {
            manager.ClearUI.SetActive(true); //클리어 UI를 활성화
            manager.timerStart = false; //타이머 일시정지
            finsihSound.Play(); //사운드 재생
        }
    }

}
