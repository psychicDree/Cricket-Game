using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseManager
{
    public PlayerManager(GameFacade facade) : base(facade) { }
    private GameData gameData;
    UnityTools.RandomOfType<int> randdomRun = new UnityTools.RandomOfType<int>();
    public override void OnInit()
    {
        //base.OnInit();
    }
    public override void OnUpdate()
    {
        //base.OnInit();
    }
    public override void OnDestroy()
    {
        //base.OnDestroy();
    }
    public void SetGameData(int over, int totalBalls, int totalBatsmen, int totalBowler, int targetScore)
    {
        gameData = new GameData(over, totalBalls, totalBatsmen, totalBowler, targetScore);
    }
    public int OnBatsmenHit(int run, int hitChance)
    {
        gameData.TotalBalls--;
        randdomRun.Add(hitChance, run);
        randdomRun.Add(100 - hitChance, 0);
        randdomRun.Add(60 - hitChance, -1);
        return randdomRun.NextItem();
    }
    
    public GameData GetGameData()
    {
        return gameData;
    }
}