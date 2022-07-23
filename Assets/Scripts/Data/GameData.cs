using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
	public int Over { get;  set; }
	public int TotalBalls { get;  set; }
	public int TotalBatsmen { get;  set; }
	public int TotalBowlers{ get;  set; }
	public int TargetScore { get;  set; }
	public int TotalScore { get;  set; }
	public int currentBowler { get;  set; }
	public DeliveryType currentDeliveryType { get; set; }

	public GameData(int over, int totalBalls, int totalBatsmen, int totalBowlers, int targetScore)
	{
		this.Over = over;
		this.TotalBalls = totalBalls;
		this.TotalBatsmen = totalBatsmen;
		this.TotalBowlers = totalBowlers;
		this.TargetScore = targetScore;
	}
}