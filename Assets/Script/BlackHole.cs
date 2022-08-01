using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    SpriteRenderer blackHole_Ren; //블랙홀 이미지
    public PlayerInfo player;
    private void Awake()
    {
        blackHole_Ren = GetComponent<SpriteRenderer>();
        blackHole_Ren.enabled = false; //이미지를 비활성화

    }
    private void Update()
    {
        if (player.rebon == true) //플레이어 부활시 
        {
            blackHole_Ren.enabled = false;  //이미지를 비활성화
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //블랙홀 범위안으로 플레이어가 들어오면
        {
            blackHole_Ren.enabled = true; //이미지를 활성화
        }
    }

   
}
