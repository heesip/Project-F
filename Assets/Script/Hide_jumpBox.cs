using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_jumpBox : MonoBehaviour
{
    public GameObject jumpBox; //점프박스 오브젝트
    public PlayerInfo player; //플레이어 정보
    AudioSource switchSound; //스위치 사운드

    private void Awake()
    {
        switchSound = GetComponent<AudioSource>();
        jumpBox.SetActive(false); //점프박스 비활성화
    }
    private void Update()
    {
        if (player.rebon == true) //플레이어 부활시
        {
            jumpBox.SetActive(false); //점프박스 비활성화
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switchSound.Play(); //사운드 재생
        jumpBox.SetActive(true); //점프 박스 활성화
    }
}
