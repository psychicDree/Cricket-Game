using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : BaseManager
{
	public GameplayManager(GameFacade facade) : base(facade)
	{
        
	}

	private GameData gameData;
	public override void OnInit()
	{
		base.OnInit();
	}
	public override void OnUpdate()
	{
		//base.OnInit();
	}

	public override void OnDestroy()
	{
		//base.OnDestroy();
	}

	public void SetGameData(int over, int ballPerOver, int totalBatsmen, int totalBowler, int targetScore)
	{
		gameData = new GameData(over, ballPerOver, totalBatsmen, totalBowler, targetScore);
	}

	public GameData GetGameData()
	{
		return gameData;
	}
}
