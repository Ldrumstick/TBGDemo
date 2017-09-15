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
    ENEMY   //轮到敌人攻击
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

    private void Start()
    {
        if(gameState == GameState.MENU)
        {
            beginBt.SetActive(true);
        }
        attackBt.SetActive(false);
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


