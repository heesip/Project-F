using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigid; //몬스터 물리작용
    Animator enemyAni; //몬스터 애니메이션
    SpriteRenderer enemyRen; //몬스터 이미지
    public int enemyMove; // 몬스터가 움직이는 방향을 정할 변수

    private void Awake()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        enemyAni = GetComponent<Animator>();
        enemyRen = GetComponent<SpriteRenderer>();

        Think(); //몬스터 움직임
    }
    private void FixedUpdate()
    {
        enemyRigid.velocity = new Vector2(enemyMove, enemyRigid.velocity.y);  //몬스터를 계속해서 이동 enemyMove가 1이면 오른쪽 -1이면 왼쪽 0이면 정지

        Vector2 frontVec = new Vector2(enemyRigid.position.x + enemyMove * 0.3f, enemyRigid.position.y);  //몬스터가 위치한 x좌표에 enemyMove와 0.3을 곱하여 더한 위치 즉 몬스터가 이동하는 방향 정면쪽에 frontVec 값을 변수로 잡음
        //Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //레이캐스트를 눈으로 보면서 값을 조정하기 위해 디버그로 표시

        RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Floor")); //레이캐스트를 frontVec값에 아래방향으로 두고 Layer가 바닥인것을 감지하게 함

        if (rayhit.collider == null)  //위에 정한 바닥을 감지하는 레이캐스트가 콜라이더를 발견하지 못하면 (바닥이 없으면)  
        {
            Turn(); //방향 전환
        }
    }


    void Think() //몬스터 움직임을 계속 변화 시켜주는 함수, 자기자신의 함수를 불러오는 재귀함수
    {
        enemyMove = Random.Range(-1, 2); //-1,0,1 사이 랜덤으로 숫자를 뽑음
        enemyAni.SetInteger("EnemyRun", enemyMove); //움직이는 애니메이션을 불러옴
        if (enemyMove != 0) //몬스터 움직임이 0이아니면
            enemyRen.flipX = enemyMove == 1; //방향에 맞게 좌우반전

        float nextThink = Random.Range(2, 5); //랜덤한 시간으로 다음 방향을 잡아줌

        Invoke("Think", nextThink);  // 위에서 잡아준 시간을 반영하여 다시 실행(무한 반복)
    }

    void Turn() //방향 전환 함수
    {
        enemyMove *= -1; //현재 이동 방향에 곱하기 -1을 하여 반대방향으로 이동하게 만듬
        enemyRen.flipX = enemyMove == 1; //방향에 맞게 좌우반전

        CancelInvoke(); //이전에 실행되어있는 Invoke 비활성화
        Invoke("Think", 3); //3초후 다시 불러옴
    }


}
