using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigid; //플레이어 물리작용
    Animator animator; //플레이어 애니메이션
    PlayerInfo playerInfo; //플레이어 정보
    AudioSource jumpSource; //점프 사운드


    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInfo = GetComponent<PlayerInfo>();
        jumpSource = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        if (playerInfo.isdead != true) //플레이어가 사망상태가 비활성화면
        {
            //캐릭터 좌우 이동 방향키 좌우 입력을 받는다 오른쪽은 1의 값을 가져오며 왼쪽은 -1값을 가져온다
            float moveInput = Input.GetAxisRaw("Horizontal");
            //위에서 받는 값을 +는 오른쪽 방향 -는 왼쪽으로 힘으로 가해준다.
            playerRigid.AddForce(Vector2.right * moveInput, ForceMode2D.Impulse);

            //플레이어 오른쪽으로 움직이는 속도가 최고 스피드를 넘으면
            if (playerRigid.velocity.x > playerInfo.maxSpeed * Time.deltaTime)
                //플레이어가 움직이는 속도가 최고스피드에 맞춰져서 움직인다 (가속도가 너무 높아지는것을 방지)
                playerRigid.velocity = new Vector2(playerInfo.maxSpeed * Time.deltaTime, playerRigid.velocity.y);

            else if (playerRigid.velocity.x < playerInfo.maxSpeed * Time.deltaTime * (-1)) //왼쪽 방향
                playerRigid.velocity = new Vector2(playerInfo.maxSpeed * Time.deltaTime * (-1), playerRigid.velocity.y);


            //레이캐스트 캐릭터 아래 방향으로 쏘고 바닥을 감지하는 용도로 설정
            RaycastHit2D playerRay = Physics2D.Raycast(playerRigid.position, Vector3.down, 1, LayerMask.GetMask("Floor"));

            if (playerRigid.velocity.y < 0) //캐릭터가 바닥에 붙어있지 않으면 ex 점프를 하거나 혹은 바닥에서 허공으로 가면
            {
                if (playerInfo.jumpCnt == 0) //위에 상황일때 점프카운트가 0이라면
                    playerInfo.jumpCnt = 1; //점프 카운트를 1로 올림

                if (playerRay.collider != null) //레이캐스트가 콜라이더에 닿으면(아무것도 닿지 않는 상황이 아니라면)
                    if (playerRay.distance < 0.75f)  //그 거리가 0.75보다 작으면
                    {
                        playerInfo.jumpCnt = 0; //점프 카운트 초기화
                    }
            }

        }

    }

    private void Update()
    {
        if (playerInfo.isdead != true) //플레이어가 사망상태가 비활성화면
        {
            //점프키를 누르고 플레이어 점프 카운트가 점프 가능한 수치보다 낮으면
            if (Input.GetButtonDown("Jump") && playerInfo.jumpCnt < playerInfo.jumpLimit)
            {
                var velo_y = playerRigid.velocity;  //어느 상황에서도 같은 점프력을 가질 수 있게 
                velo_y.y = 0; //수직으로 가속도를 0으로 잡는 변수를 잡아줌
                playerRigid.velocity = velo_y;  //점프시 수직 가속도 0
                playerRigid.AddForce(Vector2.up * playerInfo.jumpPower, ForceMode2D.Impulse); //플레이어를 위쪽 방향으로 힘을 가해줌
                playerInfo.jumpCnt++; //점프 카운트 수치 1 증가
                jumpSource.Play(); //사운드 재생
            }

            if (Mathf.Abs(playerRigid.velocity.x) < 0.3f) //플레이어가 움직이는 속도가 0.3보다 작을시 
                animator.SetBool("Run", false); //달리는 달리기 애니메이션을 비활성화
            else
                animator.SetBool("Run", true); //높으면 달리기 애니메이션을 활성화

            if (Input.GetButtonUp("Horizontal")) //좌우 방향키를 눌렀다 때면 
                //수평 가속도에 0.5를 곱해줘서 어느정도 마찰이 있다면 미끄러짐을 방지 수직 가속도는 현재가속도를 그대로 반영
                playerRigid.velocity = new Vector2(playerRigid.velocity.normalized.x * 0.5f, playerRigid.velocity.y);
        }
    }
}
