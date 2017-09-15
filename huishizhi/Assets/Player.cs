using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int playerHP = 100;
    public bool isShowingList = false;
    public GameObject attackBt;
    public Manager manager;
    public Enemy enemy;
    public Animator animator;

    private Quaternion rotation;
    private Vector3 position;


    private void Awake()
    {
        rotation = transform.localRotation;
        position = transform.position;
    }

    void Update () {
		if(manager.gameState == GameState.GAME)
        {
            if (manager.isAttacker == IsAttacker.PLAYER)
            {
                if (isShowingList == false)
                {
                    isShowingList = false;
                    attackBt.SetActive(true);
                }
            }
            else attackBt.SetActive(false);
        }
	}
    /// <summary>
    /// 当按下攻击按钮
    /// </summary>
    public void ClickAttackBt()
    {
        isShowingList = false;
        attackBt.SetActive(false);
        transform.localRotation = rotation;
        transform.position = position;
        StartCoroutine(WaitToAction());
        animator.SetTrigger("Attack");
        int i = Random.Range(10, 20);
        enemy.Damage(i);
        Debug.Log("玩家进行攻击,-" + i);
        StartCoroutine(WaitToEnemy());

    }

    IEnumerator WaitToAction()
    { yield return new WaitForSeconds(1); }

    IEnumerator WaitToEnemy()
    {
        yield return new WaitForSeconds(1);
        manager.isAttacker = IsAttacker.ENEMY;
        manager.isAttacked = false;
        
    }

    /// <summary>
    /// 受到攻击
    /// </summary>
    /// <param name="i"></param>
    public void Damage(int i)
    {
        animator.SetTrigger("Damage");
        playerHP -= i;

    }
}
