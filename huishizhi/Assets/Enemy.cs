using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Manager manager;
    public Player player;
    public int enemyHP = 100;
    public Animator animator;
    private Quaternion rotation;
    private Vector3 position;

    private void Awake()
    {
        rotation = transform.localRotation;
        position = transform.position;
    }

    private void Update()
    {
        if(manager.gameState == GameState.GAME)
        {
            if(manager.isAttacker == IsAttacker.ENEMY)
            {
                if(manager.isAttacked == false)
                {
                    transform.localRotation = rotation;
                    transform.position = position;
                    animator.SetTrigger("Attack");
                    int i = Random.Range(10, 20);
                    player.Damage(i);
                    Debug.Log("敌人攻击，-" + i);
                    manager.isAttacked = true;
                    StartCoroutine(Wait());
                }
                
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        manager.isAttacker = IsAttacker.PLAYER;
    }
    /// <summary>
    /// 受到攻击
    /// </summary>
    /// <param name="i"></param>
    public void Damage(int i)
    {
        animator.SetTrigger("Damage");
        enemyHP -= i;
    }
}
