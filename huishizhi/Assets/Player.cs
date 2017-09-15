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

    private Transform initTransform;

    private void Awake()
    {
        initTransform = transform;
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
        Debug.Log("玩家进行攻击");
        isShowingList = false;
        animator.SetTrigger("Attack");
        manager.isAttacker = IsAttacker.ENEMY;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        transform.position = initTransform.position;
        transform.rotation = initTransform.rotation;
    }
}
