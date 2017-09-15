using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    MENU, //开始菜单
    GAME, //游戏中
    OVER  //游戏结束
}

public enum IsAttacker
{
    PLAYER,  //轮到玩家攻击
    ENEMY,   //轮到敌人攻击
    OVER
}


/// <summary>
/// 用于判断当前游戏状态
/// </summary>
public class Manager : MonoBehaviour {
    public GameState gameState = GameState.MENU;
    public IsAttacker isAttacker = IsAttacker.PLAYER;

    public GameObject beginBt;
    public GameObject attackBt;
    public Player playerScript;
    public Enemy enemyScript;
    public bool isAttacked = false; //用于判断敌人是否已经攻击了一次

    private void Start()
    {
        if(gameState == GameState.MENU)
        {
            beginBt.SetActive(true);
        }
        attackBt.SetActive(false);
    }

    private void Update()
    {
        if(gameState == GameState.GAME)
        {
            if(playerScript.playerHP <= 0)
            {
                gameState = GameState.OVER;
                Debug.Log("敌人赢");
                isAttacker = IsAttacker.OVER;
                playerScript.animator.SetTrigger("Dead");
            }
            if(enemyScript.enemyHP <= 0)
            {
                gameState = GameState.OVER;
                Debug.Log("玩家赢");
                isAttacker = IsAttacker.OVER;
                enemyScript.animator.SetTrigger("Dead");
            }
        }
    }
    /// <summary>
    /// 当按下开始按钮
    /// </summary>
    public void ClickBeginBt()
    {
        gameState = GameState.GAME;
        beginBt.SetActive(false);
        playerScript.isShowingList = true;
        attackBt.SetActive(true);
    }
   
}


