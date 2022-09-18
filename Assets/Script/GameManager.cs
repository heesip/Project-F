using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerInfo player; //플레이어 정보
    public GameObject[] stageLevel; //스테이지 배열
    public int stage; //스테이지 번호
    public GameObject ClearUI; //클리어 UI
    public GameObject RetryUI; //리트라이 UI
    public Text TimeSecUI; //타이머 초 UI
    public Text TimeMinUI; //타이머 분 UI
    public float secT; // 타이머 초
    float minT; //타이머 분
    public bool timerStart; //타이머 시작 여부
    public GameObject playerC; //플레이어 캐릭터
    public FollowCam cam; //카메라

    private void Awake()
    {
        ClearUI.SetActive(false); //클리어 UI 비활성화
        RetryUI.SetActive(false); //리트라이 UI 비활성화
        timerStart = true; // 타이머 활성화
    }
    void Update()
    {
        if (timerStart == true) //타이머가 작동중이면
        {
            secT += UnityEngine.Time.deltaTime; //실제시간을 가져와서 더해줌
            TimeSecUI.text = secT.ToString("00.00");  //초에 00.00을 더해 디지털 시계처럼 보여줌
            TimeMinUI.text = minT.ToString() + ":";  //분에 : 를 추가해 초와 구분
            if (secT >= 60) // 60초가 넘으면
            {
                secT = 0.00f; //초를 0초로 돌리고
                minT++; //1분을 더함
            }
        }

        if (Input.GetButtonDown("Reset")) //리셋버튼P를 누르면
        {
            SceneManager.LoadScene(0); //씬 0번 불러옴 즉 초기화
        }
    }
    public void NextLevel() //다음 레벨 함수
    {
        ClearUI.SetActive(false); //클리어 UI 비활성화
        if (stage < 2) //스테이지 번호가 2 미만이면
        {
            stageLevel[stage].SetActive(false); //현재 스테이지를 비활성화
            stage++; //스테이지 번호 1을더함
            stageLevel[stage].SetActive(true); //해당 스테이지를 활성화
            player.transform.position = player.startPos; //플레이어 위치 스타트 위치로 변경
            player.rigid.velocity = Vector2.zero; //플레이어에게 붙은 가속도 초기화
            cam.StopCoroutine("NextCam");
            cam.StartCoroutine("NextCam");
            player.savePos = player.startPos; //플레이어 세이브 포인트 스타트 위치로 변경
            timerStart = true; //타이머 활성화

            if (stage == 2) //스테이지 번호가 2번이면 (3스테이지)
            {
                //해당 스테이지에 적용할 중력과 점프 제한 수를 수정 
                player.playerGravity = player.spaceGravity;
                player.rigid.gravityScale = player.playerGravity;
                player.jumpLimit = 1;
            }
            else
                return;

        }

        else
        {
            stageLevel[stage].SetActive(false); //현재 스테이지를 비활성화
            stageLevel[4].SetActive(true); //클리어 화면 불러옴
            playerC.SetActive(false); //캐릭터 비활성화
        }

    }
    public void Retry() //UI를 통해 사용할 Retry 플레이어에게 있는 부활 코루틴 불러옴
    {
        //부활 코루틴
        player.StopCoroutine("Rebon");
        player.StartCoroutine("Rebon");
    }

}
