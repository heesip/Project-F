using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigid; //���� �����ۿ�
    Animator enemyAni; //���� �ִϸ��̼�
    SpriteRenderer enemyRen; //���� �̹���
    public int enemyMove; // ���Ͱ� �����̴� ������ ���� ����

    private void Awake()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        enemyAni = GetComponent<Animator>();
        enemyRen = GetComponent<SpriteRenderer>();

        Think(); //���� ������
    }
    private void FixedUpdate()
    {
        enemyRigid.velocity = new Vector2(enemyMove, enemyRigid.velocity.y);  //���͸� ����ؼ� �̵� enemyMove�� 1�̸� ������ -1�̸� ���� 0�̸� ����

        Vector2 frontVec = new Vector2(enemyRigid.position.x + enemyMove * 0.3f, enemyRigid.position.y);  //���Ͱ� ��ġ�� x��ǥ�� enemyMove�� 0.3�� ���Ͽ� ���� ��ġ �� ���Ͱ� �̵��ϴ� ���� �����ʿ� frontVec ���� ������ ����
        //Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //����ĳ��Ʈ�� ������ ���鼭 ���� �����ϱ� ���� ����׷� ǥ��

        RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Floor")); //����ĳ��Ʈ�� frontVec���� �Ʒ��������� �ΰ� Layer�� �ٴ��ΰ��� �����ϰ� ��
        
        if(rayhit.collider == null)  //���� ���� �ٴ��� �����ϴ� ����ĳ��Ʈ�� �ݶ��̴��� �߰����� ���ϸ� (�ٴ��� ������)  
        {
            Turn(); //���� ��ȯ
        }
    }


    void Think() //���� �������� ��� ��ȭ �����ִ� �Լ�, �ڱ��ڽ��� �Լ��� �ҷ����� ����Լ�
    {
        enemyMove = Random.Range(-1, 2); //-1,0,1 ���� �������� ���ڸ� ����
        enemyAni.SetInteger("EnemyRun", enemyMove); //�����̴� �ִϸ��̼��� �ҷ���
        if (enemyMove != 0) //���� �������� 0�̾ƴϸ�
            enemyRen.flipX = enemyMove == 1; //���⿡ �°� �¿����

        float nextThink = Random.Range(2, 5); //������ �ð����� ���� ������ �����
        
        Invoke("Think", nextThink);  // ������ ����� �ð��� �ݿ��Ͽ� �ٽ� ����(���� �ݺ�)
    }

    void Turn() //���� ��ȯ �Լ�
    {
        enemyMove *= -1; //���� �̵� ���⿡ ���ϱ� -1�� �Ͽ� �ݴ�������� �̵��ϰ� ����
        enemyRen.flipX = enemyMove == 1; //���⿡ �°� �¿����

        CancelInvoke(); //������ ����Ǿ��ִ� Invoke ��Ȱ��ȭ
        Invoke("Think", 3); //3���� �ٽ� �ҷ���
    }

    
}
