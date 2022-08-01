using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.2f); //시작 후(생성 후) 2.2초 뒤 자신을 파괴
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); //다른 콜라이더와 물리적 충돌이 일어나면 자신을 파괴
    }
}
