using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BowlerRequest : MonoBehaviour
{
	private Camera bowlerCamera;
	private bool isEnd;
	private GameObject Bowl;
	private Rigidbody rb  ;
	private void Start()
	{
		isEnd = true;
		bowlerCamera = GetComponent<Camera>();
		Bowl = Resources.Load("Bowler/Ball") as GameObject;
	}

	private void Update()
	{
		if (isEnd)
		{
			GameObject go = Instantiate(Bowl, bowlerCamera.transform);
			Vector3 distance =  GameFacade.Instance.GetBallPosition() - go.transform.position;
			rb = go.GetComponent<Rigidbody>();
			rb.AddForce( distance * 10);
			isEnd = false;
		}
	}
	
}
