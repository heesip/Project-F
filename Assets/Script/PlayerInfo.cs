using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;

    public Rigidbody2D rigid; //플레이어 물리작용
    SpriteRenderer playerRen; //플레이어 이미지
    CapsuleCollider2D playerCollider; //플레이어 콜라이더(물리충돌)
    public GameObject dieSound; //플레이어 사망 사운드
    public GameManager manager; //게임매니저


    public Vector3 startPos = new Vector3(-7, -0.5f, 1); //시작 위치
    public Vector3 savePos; //세이브 위치

    public float maxSpeed = 220f; //플레이어 최대속도
    public float jumpPower = 8f; //플레이어 점프력
    public int jumpCnt; //점프 카운트
    public int jumpLimit; //점프 가능 횟수
    public bool isdead; //플레이어가 죽었는지 확인 
    public bool rebon; //플레이어가 부활했는지 확인 
    public float playerGravity; //플레이어가 받는 중력값
    public float earthGravity = 1.3f; //지구 중력값
    public float spaceGravity = 0.3f; //우주 중력값


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerRen = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<CapsuleCollider2D>();

        jumpCnt = 0; //점프 카운트 기본값 0
        jumpLimit = 2; //점프 가능 횟수 기본값 2회(2단 점프가능)
        isdead = false; //플레이어는 사망상태 비활성화 
        rebon = false; //플레이어가 부활 상태 비활성화
        savePos = startPos; //세이브 지점은 시작 지점으로 돌림

        //플레이어가 받는 기본 중력값은 지구 중력 값
        playerGravity = earthGravity;
        rigid.gravityScale = playerGravity;
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    private void Update()
    {
        if (Input.GetButtonDown("ReStart")) //Restart버튼을 누르면 (R)
        {
            //부활 코루틴
            StopCoroutine(Rebon());
            StartCoroutine(Rebon());
        }
        if (isdead != true)  // 플레이어 사망상태가 비활성화면
        {
            if (Input.GetButton("Horizontal")) //좌우 방향키를 누르면 
                playerRen.flipX = Input.GetAxisRaw("Horizontal") == -1; //좌우에 맞게 캐릭터 방향전환
        }


    }
    private void OnTriggerEnter2D(Collider2D collision) //플레이어가 닿으면
    {
        if (collision.gameObject.tag == "Fake") //플레이어가 Fake지형에 들어가 콜라이더에 닿으면
        {
            jumpCnt = jumpLimit; //점프카운트를 점프 수치로 변경하여 점프를 하지 못하게 만듬
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //플레이어가 콜라이더와 충돌하면
    {

        if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Enemy") //충돌 대상이 함정이나 적일때
        {
            Die(); //사망
        }
    }

    public void Die() //사망 함수
    {
        isdead = true; //사망상태 활성화
        playerRen.color = new Color(1, 1, 1, 0.4f); //반투명화
        playerRen.flipY = true; //상하 반전
        playerCollider.enabled = false; //물리적인 충돌을 받지 않기 위해 콜라이더 비활성화
        rigid.AddForce(Vector2.up * 7, ForceMode2D.Impulse); //위로 살짝 뜸
        dieSound.SetActive(true); //사망 사운드 오브젝트 활성화
        manager.RetryUI.SetActive(true); //RetryUI 활성화
    }

    public IEnumerator Rebon() //부활함수 코루틴
    {
        isdead = false; //사망상태 비활성화
        manager.RetryUI.SetActive(false); //RetryUI 비활성화
        dieSound.SetActive(false); //사망 사운드 오브젝트 비활성화
        playerRen.color = new Color(1, 1, 1, 1); //투명도 기본값
        playerRen.flipY = false; //상하 반전 복구
        playerCollider.enabled = true; //물리적인 충돌을 받기 위해 콜라이더 활성화

        //부활시 플레이어에게 붙어있는 가속도 0으로 초기화
        rigid.velocity = Vector2.zero;

        jumpCnt = 0; //점프 카운트 0으로 초기화
        transform.position = savePos; //위치를 세이브포인트 혹은 초기 위치로 이동

        //플레이어가 부활시 일부 함정을 작동 전으로 돌리기 위한 장치
        rebon = true; //부활 상태 활성화 
        yield return new WaitForSeconds(0.3f); //0.3초 후 
        rebon = false; //부활 상태 비활성화 

    }
}
