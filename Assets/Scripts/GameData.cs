using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
	public int Over { get; private set; }
	public int BallPerOver { get; private set; }
	public int TotalBatsmen { get; private set; }
	public int TotalBowlers{ get; private set; }
	public int TargetScore { get; private set; }
	public int currentBowler { get;  set; }
	public DeliveryType currentDeliveryType { get; set; }

	public GameData(int over, int ballPerOver, int totalBatsmen, int totalBowlers, int targetScore)
	{
		this.Over = over;
		this.BallPerOver = ballPerOver;
		this.TotalBatsmen = totalBatsmen;
		this.TotalBowlers = totalBowlers;
		this.TargetScore = targetScore;
	}
}