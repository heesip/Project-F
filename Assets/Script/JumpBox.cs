using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    AudioSource boxSound; //점프 박스 사운드
    public float boxPower; //박스 파워

    private void Awake()
    {
        boxSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //콜라이더에 플레이어가 닿으면
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //플레이어 정보를 할당하고
            player.rigid.AddForce(Vector2.up * boxPower, ForceMode2D.Impulse); //플레이어를 파워 힘 만큼 강제로 점프시킴
            boxSound.Play(); //사운드 재생
        }
    }
    
}
