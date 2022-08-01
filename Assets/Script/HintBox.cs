using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintBox : MonoBehaviour
{
    public GameObject hintUI; //��ƮUI
    AudioSource boxSound; //��Ʈ �ڽ� ����
    private void Awake()
    {
        boxSound = GetComponent<AudioSource>();
        hintUI.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player") //�÷��̾�� �浹��
        {
            //��Ʈ �ڷ�ƾ �۵�
            StopCoroutine("Hint"); 
            StartCoroutine("Hint");
        }
    }
    IEnumerator Hint() //��Ʈ �ڷ�ƾ
    {
        yield return null;
        boxSound.Play(); //���� ���
        hintUI.SetActive(true); //��Ʈ Ȱ��ȭ
        yield return new WaitForSeconds(2f); //2�� ��
        hintUI.SetActive(false); //��Ʈ ��Ȱ��ȭ

    }
}
