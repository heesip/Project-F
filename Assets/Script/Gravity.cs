using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //플레이어가 닿으면
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //플레이어 정보를 할당하고
            player.rigid.gravityScale = 5.5f; //플레이어가 받는 중력을 5.5로 변경
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //플레이어가 빠져나가면
        {
            PlayerInfo player = collision.GetComponent<PlayerInfo>(); //플레이어 정보를 할당하고
            player.rigid.gravityScale = player.playerGravity; //플레이어가 받는 중력을 이전으로 변경

        }
    }
}
