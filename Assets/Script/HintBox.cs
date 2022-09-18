using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintBox : MonoBehaviour
{
    public GameObject hintUI; //힌트UI
    AudioSource boxSound; //힌트 박스 사운드
    private void Awake()
    {
        boxSound = GetComponent<AudioSource>();
        hintUI.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //플레이어와 충돌시
        {
            //힌트 코루틴 작동
            StopCoroutine("Hint");
            StartCoroutine("Hint");
        }
    }
    IEnumerator Hint() //힌트 코루틴
    {
        yield return null;
        boxSound.Play(); //사운드 재생
        hintUI.SetActive(true); //힌트 활성화
        yield return new WaitForSeconds(2f); //2초 후
        hintUI.SetActive(false); //힌트 비활성화

    }
}
